#include <iostream>
#include <stdio.h>

extern "C" {
#include <libavutil/imgutils.h>
#include <libavcodec/avcodec.h>
#include <libavformat/avformat.h>
}

using namespace std;

#define pathlen 256

static const char *direpath;

static int i;

void SaveFrame(AVFrame *frame, int width, int height) {
	FILE *file;
	char filepath[pathlen];
	sprintf_s(filepath, pathlen, "%s\\%05d.jpg", direpath, i);

	cout << filepath << endl;

	fopen_s(&file, filepath, "wb");
	if (!file) {
		return;
	}

	fprintf(file, "P6\n%d %d\n255\n", width, height);
	for (int y = 0; y < height; y++) {
		fwrite(frame->data[0] + y * frame->linesize[0], 1, width * 3, file);
	}

	fclose(file);

	AVCodec *jpegCodec = avcodec_find_encoder(AV_CODEC_ID_JPEG2000);
	if (!jpegCodec) {
		return;
	}
	AVCodecContext *jpegContext = avcodec_alloc_context3(jpegCodec);
	if (!jpegContext) {
		return;
	}

	jpegContext->pix_fmt = (AVPixelFormat)frame->format;
	//jpegContext->pix_fmt = pCodecCtx->pix_fmt;
	jpegContext->height = height;
	jpegContext->width = width;

	if (avcodec_open2(jpegContext, jpegCodec, NULL) < 0) {
		return;
	}
	FILE *JPEGFile;
	char JPEGFName[256];

	AVPacket packet;
	packet.data = NULL;
	packet.size = 0;
	av_init_packet(&packet);
	int gotFrame;

	if (avcodec_encode_video2(jpegContext, &packet, frame, &gotFrame) < 0) {
		return;
	}

	sprintf(JPEGFName, "dvr-%06d.jpg", i);
	JPEGFile = fopen(JPEGFName, "wb");
	fwrite(packet.data, 1, packet.size, JPEGFile);
	fclose(JPEGFile);

	av_free_packet(&packet);
	avcodec_close(jpegContext);
}

void on_frame_decoded(AVFrame *frame) {


	SaveFrame(frame, frame->width, frame->height);

	i++;
}

int main(int argc, char *argv[]) {
	for (int i = 0; i < argc; i++) {
		cout << argv[i] << endl;
	}

	if (argc != 5) {
		cout << "args : Video File Name , Output Directory Name , First rate , Second rate" << endl;
		system("pause");
		return -1;
	}

	direpath = argv[2];
	const int first = atoi(argv[3]);
	const int second = atoi(argv[4]);

	i = 1;

	//av_register_all();

	AVFormatContext* format_context = nullptr;
	if (avformat_open_input(&format_context, argv[1], nullptr, nullptr) != 0) {
		cout << "avformat_open_input failed" << endl;
	}

	if (avformat_find_stream_info(format_context, nullptr) < 0) {
		cout << "avformat_find_stream_info failed" << endl;
	}

	AVStream *video_stream = nullptr;
	for (int i = 0; i < (int)format_context->nb_streams; ++i) {
		if (format_context->streams[i]->codecpar->codec_type == AVMEDIA_TYPE_VIDEO) {
			video_stream = format_context->streams[i];
			break;
		}
	}

	if (!video_stream) {
		cout << "No video stream ..." << endl;
	}

	AVCodec *codec = avcodec_find_decoder(video_stream->codecpar->codec_id);
	if (!codec) {
		cout << "No supported decoder ..." << endl;
	}

	AVCodecContext *codec_context = avcodec_alloc_context3(codec);
	if (!codec_context) {
		cout << "avcodec_alloc_context3 failed" << endl;
	}

	if (avcodec_parameters_to_context(codec_context, video_stream->codecpar) < 0) {
		cout << "avcodec_parameters_to_context failed" << endl;
	}

	if (avcodec_open2(codec_context, codec, nullptr) != 0) {
		cout << "avcodec_open2 failed" << endl;
	}

	AVFrame *frame = av_frame_alloc();
	AVPacket packet = AVPacket();
	while (av_read_frame(format_context, &packet) == 0) {
		if (packet.stream_index == video_stream->index) {
			if (avcodec_send_packet(codec_context, &packet) != 0) {
				cout << "avcodec_send_packet failed" << endl;
			}
			while (avcodec_receive_frame(codec_context, frame) == 0) {
				on_frame_decoded(frame);
			}
		}
		av_packet_unref(&packet);
	}

	if (avcodec_send_packet(codec_context, nullptr) != 0) {
		cout << "avcodec_send_packet failed" << endl;
	}

	while (avcodec_receive_frame(codec_context, frame) == 0) {
		on_frame_decoded(frame);
	}

	av_frame_free(&frame);
	avcodec_free_context(&codec_context);
	avformat_close_input(&format_context);
}