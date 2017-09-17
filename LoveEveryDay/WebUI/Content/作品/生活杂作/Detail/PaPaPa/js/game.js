var canvas;
var ctx;
var canvas_id;
var canvasWidth;
var canvasHeight;
var imageResources = [];
var soundResources = [];
var bugcount = 0;
var killcount = 0;
var keeptimer=null;
var nowsoundcount = 0;
var gamescore = 0;
var gametime;

function updateGame() {
    keeptimer = window.setInterval(function () {
        if (gametime > 0) {
            if (bugcount - 1 <= Math.floor(killcount * killcount / 2) && (bugcount - killcount) <= 5) {
                generateBug();
            }
        }
        else {
            window.clearInterval(keeptimer);
            keeptimer = null;
        }
    }, 300);
}

function GenAccdIn(x, rx) {
    var genx = 0;
    do {
        genx = parseFloat(Math.random() * x);
    } while (genx < rx || genx > x - rx);
    return genx;
}

function GenPositionOut(x, y, r) {
    var points = [];
    var selpoint = {};
    points.push(parseFloat(0 - Math.random() * r));
    points.push(parseFloat(x + Math.random() * r));
    points.push(parseFloat(Math.random() * x));
    points.push(parseFloat(0 - Math.random() * r));
    points.push(parseFloat(y + Math.random() * r));
    points.push(parseFloat(Math.random() * y));
    var xindex = Math.floor(Math.random() * 3);
    var yindex = Math.floor(Math.random() * (xindex == 2 ? 2 : 3)) + 3;
    return selpoint = { x: points[xindex], y: points[yindex] }
}

function gamerunimg_init(totalGameCount) {
    bugcount = 0;
    killcount = 0;
    keeptimer = null;
    nowsoundcount = 0;
    gametime = totalGameCount;
    gamescore = 0;
    imageResources["bug1_img"] = "images/bug1.png";
    imageResources["bug2_img"] = "images/bug2.png";
    imageResources["bug3_img"] = "images/bug3.png";
    imageResources["bloodsmall_img"] = "images/blood1.png";
    imageResources["bloodbig_img"] = "images/blood2.png";
    imageResources["bloodbest_img"] = "images/blood3.png";
    soundResources["bugsay"] = "sound/start.mp3";
    soundResources["pasay"] = "sound/clikMic.mp3";
}

function Bug(sx, sy, endx, endy, vx, vy, size, src, id) {
    this.sx = sx;
    this.sy = sy;
    this.x = sx;
    this.y = sy;
    this.vx = vx;
    this.vy = vy;
    this.endx = endx;
    this.endy = endy;
    this.size = size;
    this.state = 0;
    this.src = src;
    this.timer = null;
    this.total = 0;
    this.diey = 0;
    this.dies = 0;
    this.drinkcount = 0;
    this.IsBig = false;
    this.IsBest = false;
    this.IsDrink = false;
    this.elem = null;
    this.sound = null;

}

//生成一个蚊子对象
function generateBug() {
    var endx = GenAccdIn(canvasWidth, 50);
    var endy = GenAccdIn(canvasHeight, 100);
    var startpoint = GenPositionOut(canvasWidth, canvasHeight, 30);
    //console.log(endx + ',' + endy);
    new Bug(startpoint.x, startpoint.y, endx, endy, 1, 1, 35, imageResources['bug1_img']).generate();
}

//画蚊子
Bug.prototype.generate = function () {
    var _this = this;
    var img = new Image();
    img.src = _this.src;
    img.onload = function () {
        // var du = Math.atan(parseFloat((_this.endy - _this.sy) / (_this.endx - _this.sx))) * 180 / Math.PI + 45;
        var ddy = parseFloat(_this.endy - _this.sy);
        var ddx = parseFloat(_this.endx - _this.sx);
        // var xnew = Math.cos(Math.atan(ddy / ddx) - du) * Math.sqrt(ddx * ddx + ddy * ddy);
        // var ynew = Math.sin(Math.atan(ddy / ddx) - du) * Math.sqrt(ddx * ddx + ddy * ddy);
        // console.log(xnew);
        // console.log(du);
        // _this.endx = xnew;
        // _this.endy = ynew;
        _this.elem = jc.image(img, _this.sx, _this.sy, _this.size, _this.size).click(function () {
            _this.state = 3;
            _this.diey = _this.y;
            _this.dies = 0;
            var img = new Image();
            img.src = imageResources["bloodsmall_img"];
            var n_this = _this;
            img.onload = function () {
                var b_elem = jc.image(img, n_this.x + 10, n_this.y + 10, n_this.size - 13, n_this.size - 13).fadeOut(600, function () {
                    b_elem.del();
                });
            }
            if (_this.sound && !_this.sound.ended) {
                if (nowsoundcount > 0) {
                    nowsoundcount--;
                }
            }
            var sound = new Audio();
            sound.loop = false;
            sound.src = soundResources["pasay"];
            sound.loop = false;
            _this.sound = sound;
            _this.sound.play();
        });
        //_this.elem.rotate(du, 'center')

        _this.state = 1;
        _this.BugGo();
        bugcount++;
    };
}

//检查状态
Bug.prototype.BugGo = function () {
    var _this = this;
    _this.timer = window.setInterval(function () {
        if (gametime > 0) {
            if (_this.state == 1) {
                //  console.log(nowsoundcount);
                var sound = new Audio();
                sound.loop = false;
                sound.src = soundResources["bugsay"];
                if (nowsoundcount <= 0) {
                    _this.sound = sound;
                    nowsoundcount++;
                    _this.sound.play();
                }
                _this.fly();
            }
            else if (_this.state == 2) {
                if (_this.sound) {
                    if (_this.sound) {
                        _this.sound.pause();
                        _this.sound = null;
                        nowsoundcount--;
                    }
                }
                _this.drink();
            }
            else if (_this.state == 3) {
                _this.die();
            }
        }
        else {
            if (_this.sound && !_this.sound.ended) {
                _this.sound.pause();
                _this.sound = null;
            }
            _this.state == 4;
            window.clearInterval(_this.timer);
            _this.timer = null;
        }
    }, 30);

}


//飞入
Bug.prototype.fly = function () {
    if (this.sound && this.sound.ended) {
        this.sound = null;
        if (nowsoundcount > 0) {
            nowsoundcount--;
        }
    }
    if ((this.sx > this.endx ? this.x > this.endx : this.x < this.endx) && (this.sy > this.endy ? this.y > this.endy : this.y < this.endy)) {
        this.x += (this.sx > this.endx) ? -this.vx : this.vx;
        this.y += (this.sy > this.endy) ? -this.vy : this.vy;
        this.elem.animate({ x: this.x, y: this.y });

    }
    else {
        this.state = 2;
        this.total = 0;
        this.IsDrink = false;

    }
}

//缩放
Bug.prototype.BecomeBiger = function (bugsrc, bloodimg, type) {
    if (this.sound && this.sound.ended) {
        this.sound = null;
        if (nowsoundcount > 0) {
            nowsoundcount--;
        }
    }
    var img = new Image();
    var _this = this;
    _this.src = bugsrc;
    img.src = _this.src;
    img.onload = function () {
        _this.elem.del();
        var addsize = 3;
        if (type) {
            _this.IsBest = true;
            addsize = 6;
        }
        _this.elem = jc.image(img, _this.x, _this.y, _this.size + addsize, _this.size + addsize).click(function () {

            _this.state = 3;
            _this.diey = _this.y;
            _this.dies = 0;
            var img = new Image();
            img.src = bloodimg;
            var n_this = _this;
            img.onload = function () {
                var b_elem = jc.image(img, n_this.x, n_this.y + 10, n_this.size + addsize, n_this.size + addsize).fadeOut(1000, function () {
                    b_elem.del();
                });
            }
            if (_this.sound && !_this.sound.ended) {
                if (nowsoundcount > 0) {
                    nowsoundcount--;
                }
            }
            var sound = new Audio();
            sound.loop = false;
            sound.src = soundResources["pasay"];
            _this.sound = sound;
            _this.sound.play();
        });
        _this.IsBig = true;
    }
}

//吸血
Bug.prototype.drink = function () {
    if (!this.IsDrink) {
        if (this.total <= 10 && this.total >= -1) {
            this.elem.scale(1.01);
            this.total++;
        }
        else {
            if (this.drinkcount > 3 && this.drinkcount < 8 && !this.IsBig && !this.IsBest) {
                this.BecomeBiger(imageResources['bug2_img'], imageResources["bloodbig_img"]);
            }
            if (this.drinkcount >= 8 && this.IsBig && !this.IsBest) {
                this.BecomeBiger(imageResources['bug3_img'], imageResources["bloodbest_img"], 1);
            }
            this.drinkcount++;
            this.IsDrink = true;
        }
    }

    if (this.IsDrink) {
        if (this.total >= 0) {
            this.elem.scale(0.99);
            this.total--;
        }
        else {
            this.IsDrink = false;
        }
    }
}

//掉落
Bug.prototype.die = function () {
    if (this.y <= canvasHeight) {
        this.y = this.diey + parseFloat(1 / 2) * 9.8 * this.dies * this.dies / 5;
        this.dies++;
        this.elem.animate({ y: this.y });
    }
    else {
        //消除对象
        window.clearInterval(this.timer);

        killcount++;
        var thispa = 1;
        if (this.IsBig) {
            thispa = 2;
        }
        if (this.IsBest) {
            thispa = 4;
        }
        gamescore += thispa;
        this.elem.del();
    }
}
