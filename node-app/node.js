var hosturl = "0.0.0.0";
var wsport  = 3100;
var oscport = 3334;


// run WebSocket server
var WebSocketServer = require('ws').Server;
var wss = new WebSocketServer({host: hosturl, port: wsport });

// run OSC Sender
var oscsender = require('omgosc').UdpSender;
var sender = new oscsender(hosturl, oscport);

console.log('running WebSocket Server....');

// web socket
wss.on('connection', function (ws) {

    ws.on('message', function (message) {
        //console.log(message.data);

        //console.log(message);
        var mes = JSON.parse(message);
        if(mes.osc){
            if(mes.data.length == 1){
                sender.send(mes.path,mes.type,[mes.data]);
            }else if(mes.data.length > 1){
                var dataArr = [];
                mes.data.forEach(function(data){
                    dataArr.push([data]);
                });
                sender.send(mes.path,mes.type,dataArr);
            }
        }
    });
});
