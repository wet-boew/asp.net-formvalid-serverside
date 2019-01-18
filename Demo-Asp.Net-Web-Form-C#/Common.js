////Jquery-Wet-Js Example (Remove comments and run)
//$(document).on("wb-ready.wb", pizza);

//function pizza() {
//    alert('pizza!');
//};

$(document).on("wb-ready.wb", AddJsRequired);
function AddJsRequired() {
    $(".required_js").attr("required", true);
}
