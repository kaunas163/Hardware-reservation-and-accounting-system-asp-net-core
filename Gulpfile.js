const gulp      = require('gulp');
const sass      = require('gulp-sass');
// const concat    = require('gulp-concat');
const concatCss = require('gulp-concat-css');
const cleanCss  = require('gulp-clean-css');
const uglify    = require('gulp-uglify');
const rename    = require("gulp-rename");
const babel     = require('gulp-babel');
const browserify = require('browserify');
const source    = require('vinyl-source-stream');
const buffer    = require('vinyl-buffer');
const del       = require('del');
const fs        = require('fs-extra');

function copyFiles(done) {
    gulp.src('./node_modules/@fortawesome/fontawesome-free/webfonts/*')
    .pipe(gulp.dest('./wwwroot/webfonts/'));

    gulp.src('./node_modules/lightbox2/dist/images/*')
    .pipe(gulp.dest('./wwwroot/images/'));

    done();
}

function styles(done) {
    gulp.src([
        './node_modules/bootstrap/scss/bootstrap.scss',
        './node_modules/@fortawesome/fontawesome-free/scss/fontawesome.scss',
        './node_modules/@fortawesome/fontawesome-free/scss/regular.scss',
        './node_modules/@fortawesome/fontawesome-free/scss/solid.scss',
        './node_modules/@fortawesome/fontawesome-free/scss/brands.scss',
        './node_modules/@fullcalendar/core/main.css',
        './node_modules/@fullcalendar/daygrid/main.css',
        './node_modules/@fullcalendar/timegrid/main.css',
        './node_modules/lightbox2/src/css/lightbox.css',
        './Styles/main.scss'
    ])
    .pipe(sass().on('error', sass.logError))
    .pipe(concatCss('styles.css', {'rebaseUrls': false}))
    .pipe(cleanCss())
    .pipe(rename({ suffix: '.min' }))
    .pipe(gulp.dest('./wwwroot/css/'));
    done();
}

function cleanTemp(done) {
    del(['./wwwroot/temp/*']);
    done();
}

function es6common(done) {
    fs.ensureDirSync('./wwwroot/temp');

    gulp.src([
        './Scripts/*.js',
        '/Scripts/**/*.js',
    ])
    .pipe(babel())
    .pipe(gulp.dest('./wwwroot/temp/'));

    done();
}

function scripts(done) {
    browserify([
        './node_modules/jquery/dist/jquery.slim.js',
        './node_modules/jquery-validation/dist/jquery.validate.js', // TODO: include localization of this
        './node_modules/popper.js/dist/umd/popper.js',
        './node_modules/bootstrap/dist/js/bootstrap.js',
        './node_modules/lightbox2/src/js/lightbox.js',
        // './node_modules/vue/dist/vue.js',
        './wwwroot/temp/index.js',
    ])
    .bundle()
    .pipe(source('scripts.js'))
    .pipe(buffer())
    .pipe(uglify())
    .pipe(rename({ suffix: '.min' }))
    .pipe(gulp.dest('./wwwroot/js/'));
    done();
}

function watch(done) {
    gulp.watch('./Styles/**/*.scss', gulp.series(styles));
    gulp.watch('./Scripts/**/*.js', gulp.series(es6common, scripts, cleanTemp));
    done();
}

exports.es6common = es6common;

exports.copyFiles = copyFiles;
exports.styles = styles;
exports.scripts = scripts;

exports.cleanTemp = cleanTemp;

exports.watch = watch;

exports.default = gulp.series(es6common, gulp.parallel(copyFiles, styles, scripts), gulp.parallel(cleanTemp, watch));
