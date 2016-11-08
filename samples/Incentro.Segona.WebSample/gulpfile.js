/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp");
var del = require("del");

gulp.task("clean", function() {
    return del(["./wwwroot/"]);
});

gulp.task("bootstrap", function() {
    return gulp.src("./bower_components/bootstrap/dist/css/*.min.css")
        .pipe(gulp.dest("./wwwroot/css/"));
});

gulp.task("jquery", function() {
    return gulp.src("./bower_components/jquery/dist/jquery.js")
        .pipe(gulp.dest("./wwwroot/js/"));
});

gulp.task("scripts", function() {
    return gulp.src("./Static/Scripts/*")
        .pipe(gulp.dest("./wwwroot/js/"));
});

gulp.task('default', ["clean", "scripts", "bootstrap", "jquery"]);