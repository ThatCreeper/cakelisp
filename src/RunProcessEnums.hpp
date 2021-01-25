#pragma once

// Update ProcessCommandArgumentTypeToString() after modifying this enum
enum ProcessCommandArgumentType
{
	ProcessCommandArgumentType_None = 0,

	ProcessCommandArgumentType_String,

	ProcessCommandArgumentType_SourceInput,
	ProcessCommandArgumentType_ObjectOutput,
	ProcessCommandArgumentType_CakelispHeadersInclude,
	ProcessCommandArgumentType_IncludeSearchDirs,
	ProcessCommandArgumentType_AdditionalOptions,

	ProcessCommandArgumentType_ObjectInput,
	ProcessCommandArgumentType_DynamicLibraryOutput,
	ProcessCommandArgumentType_LibrarySearchDirs,
	ProcessCommandArgumentType_Libraries,
	ProcessCommandArgumentType_LibraryRuntimeSearchDirs,
	// Pass to the linker, e.g. on clang, add -Wl,
	ProcessCommandArgumentType_LinkerArguments,
	ProcessCommandArgumentType_ExecutableOutput
};
