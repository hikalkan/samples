/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./wwwroot/app/Pages/Index.js");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./wwwroot/app/Dtos/PersonDto.js":
/*!***************************************!*\
  !*** ./wwwroot/app/Dtos/PersonDto.js ***!
  \***************************************/
/*! exports provided: PersonDto */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"PersonDto\", function() { return PersonDto; });\nvar PersonDto = /** @class */ (function () {\r\n    function PersonDto(name) {\r\n        this.name = name;\r\n        $('.content').append('<p>' + name + '</p>');\r\n    }\r\n    return PersonDto;\r\n}());\r\n\r\n//# sourceMappingURL=PersonDto.js.map\n\n//# sourceURL=webpack:///./wwwroot/app/Dtos/PersonDto.js?");

/***/ }),

/***/ "./wwwroot/app/Pages/Index.js":
/*!************************************!*\
  !*** ./wwwroot/app/Pages/Index.js ***!
  \************************************/
/*! exports provided: Index */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"Index\", function() { return Index; });\n/* harmony import */ var _Dtos_PersonDto__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../Dtos/PersonDto */ \"./wwwroot/app/Dtos/PersonDto.js\");\n\r\nvar Index = /** @class */ (function () {\r\n    function Index() {\r\n    }\r\n    Index.prototype.init = function () {\r\n        var john = new _Dtos_PersonDto__WEBPACK_IMPORTED_MODULE_0__[\"PersonDto\"](\"john\");\r\n        var david = new _Dtos_PersonDto__WEBPACK_IMPORTED_MODULE_0__[\"PersonDto\"](\"david\");\r\n        console.log('initialized Pages.Index');\r\n        console.log(john.name);\r\n        console.log(david.name);\r\n    };\r\n    return Index;\r\n}());\r\n\r\nnew Index().init();\r\n//# sourceMappingURL=Index.js.map\n\n//# sourceURL=webpack:///./wwwroot/app/Pages/Index.js?");

/***/ })

/******/ });