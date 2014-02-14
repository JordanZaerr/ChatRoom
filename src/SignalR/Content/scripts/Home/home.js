(function () {
  var chatRoomHub = $.connection.chatRoomHub,
      messagesHolder = {},
      homeModel = {
        name: ko.observable(),
        currentRoom: ko.observable(),
        messages: ko.observableArray(),
        currentRoom: ko.observable('Lobby'),
        currentMessage: ko.observable(),
        rooms: ko.observableArray(),
        sendMessage: function() {
          chatRoomHub.server.send(homeModel.currentRoom(), homeModel.currentMessage());
          homeModel.currentMessage('');
        },
        createRoom: function () {
          bootbox.prompt("What would you like to call the new room?", function (roomName) {
            $.ajax({
              type:'POST',
              url: 'createroom',
              data: {RoomName: roomName},
            });
          });
        },
        changeRooms: function (room) {
          var current = homeModel.currentRoom();
          chatRoomHub.server.leaveGroup(current);
          messagesHolder[current] = homeModel.messages();
          homeModel.currentRoom(room);
          homeModel.messages(messagesHolder[room] || []);
          chatRoomHub.server.joinGroup(room);
        }
      };

  bootbox.prompt("Please enter your username", function (username) {
    homeModel.name(username);
    chatRoomHub.state.name = username;
    $.connection.hub.logging = true;
    $.connection.hub.start().done(function () {
      console.log('Connected, ConnectionId: ' + $.connection.hub.id);
      console.log('Using transport method: ' + $.connection.hub.transport.name);
      chatRoomHub.server.joinGroup(homeModel.currentRoom());
    });
  });

  chatRoomHub.client.broadcastMessage = function (name, message) {
    homeModel.messages.push({
      name: name,
      message: message
    });
  };

  chatRoomHub.client.roomCreated = function(name) {
    homeModel.rooms.push(name);
  };

  $.ajax({
    url: 'rooms',
    success: function (data) {
      homeModel.rooms(data.Rooms);
    }
  });

  ko.applyBindings(homeModel);
})();