#include "stdafx.h"
#include "RAW.h"

void raw(const char *FromPath, const char *ToPath) {
	//av_register_all();

	AVFormatContext* format_context = nullptr;
	if (avformat_open_input(&format_context, FromPath, nullptr, nullptr) != 0) {
		printf("avformat_open_input failed\n");
	}

	if (avformat_find_stream_info(format_context, nullptr) < 0) {
		printf("avformat_find_stream_info failed\n");
	}

	AVStream *video_stream = nullptr;
	for (int i = 0; i < (int)format_context->nb_streams; ++i) {
		if (format_context->streams[i]->codecpar->codec_type == AVMEDIA_TYPE_VIDEO) {
			video_stream = format_context->streams[i];
			break;
		}
	}

	if (!video_stream) {
		printf("No video stream ...\n");
	}

	AVCodec *codec = avcodec_find_decoder(video_stream->codecpar->codec_id);
	if (!codec) {
		printf("No supported decoder ...\n");
	}

	AVCodecContext *codec_context = avcodec_alloc_context3(codec);
	if (!codec_context) {
		printf("avcodec_alloc_context3 failed\n");
	}

	if (avcodec_parameters_to_context(codec_context, video_stream->codecpar) < 0) {
		printf("avcodec_parameters_to_context failed\n");
	}

	if (avcodec_open2(codec_context, codec, nullptr) != 0) {
		printf("avcodec_open2 failed\n");
	}

	AVFrame *frame = av_frame_alloc();
	AVPacket packet = AVPacket();
	while (av_read_frame(format_context, &packet) == 0) {
		if (packet.stream_index == video_stream->index) {
			if (avcodec_send_packet(codec_context, &packet) != 0) {
				printf("avcodec_send_packet failed\n");
			}
			while (avcodec_receive_frame(codec_context, frame) == 0) {
				on_frame_decoded(frame);
			}
		}
		av_packet_unref(&packet);
	}

	if (avcodec_send_packet(codec_context, nullptr) != 0) {
		printf("avcodec_send_packet failed");
	}
	while (avcodec_receive_frame(codec_context, frame) == 0) {
		on_frame_decoded(frame);
	}

	av_frame_free(&frame);
	avcodec_free_context(&codec_context);
	avformat_close_input(&format_context);
}

int i = 0;

void SaveFrame(AVFrame *frame, int width, int height) {
	FILE *file;
	char filename[32];

	sprintf_s(filename, "%05d.jpg", i);
	fopen_s(&file, filename, "wb");
	if (!file) {
		return;
	}

	fprintf(file, "P6\n%d %d\n255\n", width, height);
	for (int y = 0; y<height; y++) {
		fwrite(frame->data[0] + y * frame->linesize[0], 1, width * 3, file);
	}

	fclose(file);
}

void on_frame_decoded(AVFrame *frame) {


	SaveFrame(frame, frame->width, frame->height);

	i++;
}