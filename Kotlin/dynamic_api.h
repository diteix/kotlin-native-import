#ifndef KONAN_DYNAMIC_H
#define KONAN_DYNAMIC_H
#ifdef __cplusplus
extern "C" {
#endif
#ifdef __cplusplus
typedef bool            dynamic_KBoolean;
#else
typedef _Bool           dynamic_KBoolean;
#endif
typedef unsigned short     dynamic_KChar;
typedef signed char        dynamic_KByte;
typedef short              dynamic_KShort;
typedef int                dynamic_KInt;
typedef long long          dynamic_KLong;
typedef unsigned char      dynamic_KUByte;
typedef unsigned short     dynamic_KUShort;
typedef unsigned int       dynamic_KUInt;
typedef unsigned long long dynamic_KULong;
typedef float              dynamic_KFloat;
typedef double             dynamic_KDouble;
typedef void*              dynamic_KNativePtr;
struct dynamic_KType;
typedef struct dynamic_KType dynamic_KType;



typedef struct {
  /* Service functions. */
  void (*DisposeStablePointer)(dynamic_KNativePtr ptr);
  void (*DisposeString)(const char* string);
  dynamic_KBoolean (*IsInstance)(dynamic_KNativePtr ref, const dynamic_KType* type);

  /* User functions. */
  struct {
    struct {
      const char* (*hello)();
    } root;
  } kotlin;
} dynamic_ExportedSymbols;
extern dynamic_ExportedSymbols* dynamic_symbols(void);
#ifdef __cplusplus
}  /* extern "C" */
#endif
#endif  /* KONAN_DYNAMIC_H */
