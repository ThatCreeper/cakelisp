(skip-build)

(set-cakelisp-option executable-output "bin/cakelisp.exe")

(add-c-search-directory module "src")
(add-cpp-build-dependency
 "Tokenizer.cpp"
 "Evaluator.cpp"
 "Utilities.cpp"
 "FileUtilities.cpp"
 "Converters.cpp"
 "Writer.cpp"
 "Generators.cpp"
 "GeneratorHelpers.cpp"
 "RunProcess.cpp"
 "OutputPreambles.cpp"
 "DynamicLoader.cpp"
 "ModuleManager.cpp"
 "Logging.cpp"
 "Main.cpp")

(add-build-options "/DWINDOWS" "/EHsc")

;; (defun-comptime cakelisp-link-hook (manager (& ModuleManager)
;;                                     linkCommand (& ProcessCommand)
;;                                     linkTimeInputs (* ProcessCommandInput) numLinkTimeInputs int
;;                                     &return bool)
;;   (Log "Cakelisp: Adding link arguments\n")
;;   ;; Dynamic loading
;;   (on-call (field linkCommand arguments) push_back
;;            (array ProcessCommandArgumentType_String
;;                   "-ldl"))
;;   ;; Expose Cakelisp symbols for compile-time function symbol resolution
;;   (on-call (field linkCommand arguments) push_back
;;            (array ProcessCommandArgumentType_String
;;                   "-Wl,--export-dynamic"))
;;   (return true))

;; (add-compile-time-hook pre-link cakelisp-link-hook)

(set-cakelisp-option build-time-compiler "cl.exe")
(set-cakelisp-option build-time-compile-arguments
                     "/c" 'source-input 'object-output
                     'include-search-dirs 'additional-options)

(set-cakelisp-option compile-time-compiler "cl.exe")
(set-cakelisp-option compile-time-compile-arguments
                     "/c" 'source-input 'object-output
                     'cakelisp-headers-include)
;; "-fPIC"

(set-cakelisp-option build-time-linker "link.exe")
(set-cakelisp-option build-time-link-arguments
                     'executable-output 'object-input)

;; Use separate build configuration in case other things build files from src/
(add-build-config-label "Bootstrap_Windows")