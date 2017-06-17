
var photoId;

function updateProgress() {

    console.log("зашли в updateProgress"); //

    var inputsProduct = $(".field-product");
    var inputsValue = $(".field-value");
    var photoes = $(".photo-row");

    console.log("inputsProduct = " + inputsProduct.length); //
    console.log("inputsValue = " + inputsValue.length); //
    console.log("photoes = " + photoes.length); //

    var stepProduct = Math.round(40 / inputsProduct.length);
    var stepValue = Math.round(30 / inputsValue.length);
    var stepPhoto = Math.round(30 / photoes.length);

    console.log("inputsProduct = " + stepProduct); //
    console.log("inputsValue = " + stepValue); //
    console.log("photoes = " + stepPhoto); //

    var progressValue = 0;

    $(".field-product").each(function(index) {
        if ($(this).val().length > 2 && $(this).val() !== "0,00") {
            progressValue += stepProduct;
        }
    });

    inputsValue.each(function(index) {
        if ($(this).val().length > 0) {
            progressValue += stepValue;
        }
    });

    photoes.each(function(index) {

        progressValue += stepPhoto;
    });

    console.log("progressValue = " + progressValue);

    if (progressValue > 60) {
        $("#submit").prop("disabled", false);

        $("#submit").removeClass("btn-danger");
        $("#submit").removeClass("btn-success");
        $("#submit").addClass("btn-warning");

        $(".span-text-submit").text("Добавьте фотографий товара").css("color", "orange");

        $(".span-icon-submit").removeClass("glyphicon-ban-circle");
        $(".span-icon-submit").removeClass("glyphicon-ok");
        $(".span-icon-submit").addClass("glyphicon-warning-sign").css("color", "orange");

        if (progressValue > 85) {
            $("#submit").removeClass("btn-warning");
            $("#submit").addClass("btn-success");

            $(".span-text-submit").text("Готово").css("color", "forestgreen");

            $(".span-icon-submit").removeClass("glyphicon-warning-sign");
            $(".span-icon-submit").addClass("glyphicon-ok").css("color", "forestgreen");
        }
    } else {
        $("#submit").prop("disabled", true);
        $("#submit").removeClass("btn-warning");
        $("#submit").removeClass("btn-success");
        $("#submit").addClass("btn-danger");

        $(".span-text-submit").text("Заполните больше полей для создания товара").css("color", "red");

        $(".span-icon-submit").removeClass("glyphicon-warning-sign");
        $(".span-icon-submit").removeClass("glyphicon-ok");
        $(".span-icon-submit").addClass("glyphicon-ban-circle").css("color", "red");

    }
    if (progressValue > 100)
        progressValue = 100;
    $(".progress-bar").css("width", progressValue + "%");
    $(".progress-bar").text(progressValue + "%");

}

function photoChange(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function(e) {
            createNewTableRow(photoId, e.target.result, input.files[0].name, input.files[0].size);
            $("input[id=inp-" + photoId + "]").hide();

            photoId++;
            $("#addPhoto").append(createPhotoInput(photoId));
        };
        reader.readAsDataURL(input.files[0]);

    }
}

function createPhotoInput(photoId) {
    var newInput;
    return newInput = $("<input/>", {
            id: "inp-" + photoId,
            type: "file",
            accept: "image/png, image/jpeg, image/gif",
            name: "uploadImage"
        }).addClass("upload")
        .change(function() {
            photoChange(this);
        });
}

function createPhotoImage(protoId, source) {
    var newImg;
    return newImg = $("<img/>", {
        id: "img-" + protoId,
        src: source,
        width: "140",
        height: "140"
    }).addClass("img-responsive img-thumbnail");
}

function createPhotoName(photoId, photoName) {
    var newNameInput;
    return newNameInput = $("<label/>", {
        id: "name-" + photoId,
        name: "Name",
        text: photoName
    });
}

function createPhotoSize(photoId, fileSize) {
    var newTitleInput;
    var fSExt = new Array("Bytes", "KB", "MB", "GB");
    var i = 0;

    while (fileSize > 900) {
        fileSize /= 1024;
        i++;
    }

    return newTitleInput = $("<label/>", {
        id: "size-" + photoId,
        name: "size",
        text: (Math.round(fileSize * 100) / 100) + " " + fSExt[i]
    });
}

function createPhotoRatio(photoId) {
    var arrayOptions = new Array("1x1", "4x3", "16x9");

    var newRatio = $("<select/>", {
        id: "select-" + photoId,
        name: "aspectRatio"
    }).css("width", "100px").addClass("form-control");

    for (var val in arrayOptions) {
        if (arrayOptions.hasOwnProperty(val)) {
            $("<option />", {
                value: arrayOptions[val],
                text: arrayOptions[val]
            }).appendTo(newRatio);
        }
    }

    return newRatio;
}

function createDeleteButton(photoId) {
    var newBtnDel;
    return newBtnDel = $("<label/>", {
            id: "delete-" + photoId,
            name: "Delete",
            text: "Delete"
        }).addClass("btn btn-danger")
        .on("click", function() {
            var delPhotoId = parseInt($(this).attr("id").substr(7));

            console.log("delPhotoId = " + delPhotoId);

            $("tr[id=tr-" + delPhotoId + "]").remove();
            $("input[id=inp-" + delPhotoId + "]").remove();
            updateProgress();
        });
}

function createNewTableRow(photoId, sourcePhoto, photoName, fileSize) {
    var newTr = $("<tr/>", { id: "tr-" + photoId }).addClass("photo-row");

    $("#photoTable").append(
        newTr.append(
            $("<td/>").append(createPhotoImage(photoId, sourcePhoto)),
            $("<td/>").append(createPhotoName(photoId, photoName)),
            $("<td/>").append(createPhotoSize(photoId, fileSize)),
            $("<td/>").append(createPhotoRatio(photoId)),
            $("<td/>").append(createDeleteButton(photoId)))
    );
    updateProgress();
}

function initPage() {
    photoId = 1;
    $("#addPhoto").append(createPhotoInput(photoId));
    CKEDITOR.replace("Discription");
}

$('input[type="text"]').change(function() {
    updateProgress();
    return false;
});
initPage();