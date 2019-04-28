const gulp      = require('gulp');
const sass      = require('gulp-sass');
const concat    = require('gulp-concat');
const concatCss = require('gulp-concat-css');
const cleanCss  = require('gulp-clean-css');
const uglify    = require('gulp-uglify');
const rename    = require("gulp-rename");

// function fonts(done) {
//     gulp.src('./node_modules/@fortawesome/fontawesome-free/webfonts/*')
//         .pipe(gulp.dest('./assets/webfonts'));
//     done();
// }

function styles(done) {
    gulp.src([
        './node_modules/bootstrap/scss/bootstrap.scss',
        // './node_modules/@fullcalendar/core/main.css',
        // './node_modules/@fullcalendar/daygrid/main.css',
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

function scripts(done) {
    gulp.src([
        './node_modules/jquery/dist/jquery.slim.js',
        './node_modules/jquery-validation/dist/jquery.validate.js', // TODO: include localization of this
        './node_modules/popper.js/dist/umd/popper.js',
        './node_modules/bootstrap/dist/js/bootstrap.js',
        // './node_modules/@fullcalendar/core/main.js',
        // './node_modules/@fullcalendar/daygrid/main.js',
        './node_modules/lightbox2/src/js/lightbox.js',
        // './Content/scripts/index.js'
    ])
    .pipe(concat('scripts.js'))
    .pipe(uglify())
    .pipe(rename({ suffix: '.min' }))
    .pipe(gulp.dest('./wwwroot/js/'));
    done();
}

function watch(done) {
    gulp.watch('./Styles/**/*.scss', gulp.series(styles));
    // gulp.watch('./Content/scripts/**/*.js', gulp.series(scripts));
    done();
}

// exports.default = gulp.series(gulp.parallel(fonts, styles, scripts), watch);

exports.default = gulp.series(gulp.parallel(styles, scripts), watch);
