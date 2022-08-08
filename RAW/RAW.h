#pragma once

#ifdef RAWDLL_EXPORTS
#define RAWDLL_API __declspec(dllexport) 
#else
#define RAWDLL_API __declspec(dllimport) 
#endif

extern "C" {
	RAWDLL_API void raw(const char *FromPath, const char *ToPath);
}

extern void on_frame_decoded(AVFrame *frame);