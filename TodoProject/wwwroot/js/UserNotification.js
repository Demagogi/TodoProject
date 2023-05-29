document.addEventListener('DOMContentLoaded', function () {
	//create connection
	var connectionUser = new signalR.HubConnectionBuilder().withUrl("/hubs/user").build();


	//connect to methods that hub invokes aka recive notification from hub
	connectionUser.on("notifyTaskStatus", newNotificationForUser);

	//invoke hub methods aka send notification to hub
	function newNotificationForUser() {
		toastr.info('Status of your to do has changed, please check.');
		console.log("notified");
	}

	//start connection
	function fullfilled() {
		// do something on start
		console.log("Connectiong was succesful");
	}

	function rejected() {
		//rejected logs
		console.log("SignalR Connection Failed");
	}

	connectionUser.start().then(fullfilled, rejected);
});