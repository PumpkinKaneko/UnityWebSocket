var WebSocketServer = require('ws').Server
  , wss = new WebSocketServer({ port: 8080 });

wss.on('connection', function connection(ws) {

	ws.on('message', function incoming(message) {
		ws.send('received message: ' + message)
  });

  ws.send('connect!');
});
