/**
 *
 * Created by kenjisaito on 2/11/16.
 */

var url = window.document.location.host.replace(/:.*/, '');
var wsport = 3100;  // WebSocketのPort番号

// WebSocket開始
console.log(url);
var wsOsc = {};
wsOsc.ws = new WebSocket('ws://' + url + ':'+wsport);
wsOsc.status = 0;       // 0: 送れる 1: 送れない
wsOsc.ws.onopen = function(){
    wsOsc.status = 1;   // 送れる
};
wsOsc.ws.onclose = function(){
    wsOsc.status = 0;   // 送れない
};
wsOsc.send = function(path,type,data){
    var jsonobj = {"osc":"WsOscSend","path":path,"type":type,"data":data};
    var json = JSON.stringify(jsonobj);

    // 送れれば送る
    if(wsOsc.status){
        wsOsc.ws.send(json);
    }
};

window.addEventListener("mousemove", function(ev){
    //console.log(ev.pageX/10);
    //console.log(ev.pageY);

    wsOsc.send('/osc/mousemove', 'f', [
        10.3
    ]);

});

window.addEventListener("touchmove", function(ev){
    var touch = ev.touches[0];

    var pageX = touch.clientX;
    var pageY = touch.clientY;

    ctx.clearRect(0, 0, window.innerWidth, window.innerHeight);
    ctx.fillStyle = "0x000";
    ctx.beginPath();
    ctx.arc(pageX, pageY, 10, 0, 2 * Math.PI, false);
    ctx.fill();

    ctx.beginPath();
    ctx.fillStyle = "0x000";

    var mouseString = "(x, y) = (" + pageX + ", " + pageY + " )";
    ctx.fillText( mouseString, 15, 45);

    wsOsc.send('/osc/mousemove', 'ff', [
        (pageX - window.innerWidth/2) /window.innerWidth, (pageY - window.innerHeight/2)/window.innerHeight
    ]);

    ev.preventDefault();
});


document.body.style.margin = "0";
var canvas = document.createElement("canvas");
var scale = window.devicePixelRatio;

canvas.width = window.innerWidth * scale;
canvas.height = window.innerHeight * scale;
canvas.style.width = window.innerWidth + "px";
canvas.style.height = window.innerHeight + "px";
var ctx = canvas.getContext('2d');
ctx.font="24px Arial";

document.body.appendChild(canvas);
ctx.scale(scale, scale);

