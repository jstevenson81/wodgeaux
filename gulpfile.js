var
	src = './src/',
	scripts = src + 'scripts/',
	app = scripts + 'app/',	
	$ = require('gulp-load-plugins')({ lazy: true }),
    args = require('yargs').argv,
    del = require('del'),
    gulp = require('gulp');
	
gulp.task('clean-app', function() {
	
	return clean(app + '**/*.js*');
	
})
	
	
function clean(path, done) {
    log('Cleaning: ' + $.util.colors.blue(path));
    del(path).then(done);
}

function log(msg) {
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.blue(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.blue(msg));
    }
}