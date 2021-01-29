function toggleSideMenu(el) {
    console.log(el);
    $(el).slideToggle('fast');
}

function openSideMenu(el) {
    setTimeout(() => { $(el).slideToggle('fast'); }, 500)
}


function exectFunctions() {
    window.on_page_functions = [];
    window.on_page_functions.forEach((func) => {
        Metro.utils.exec(func, []);
    });
}

function GetReferenceObject(dotNetObject) {
    console.log(dotNetObject);
    return dotNetObject;
}

function InitMenu(dotNetobject) {
    CheckRoute();
    $(".navview-menu").on(Metro.events.click, "a", function (e) {
        var href = $(this).attr("href");
        var pane = $(this).closest(".navview-pane");
        if (href === "#") {
            return false;
        }

        exectFunctions();

        if (pane.hasClass("open")) {
            pane.removeClass("open");
        }

        pane.find("li").removeClass("active");
        $(this).closest("li").addClass("active");

        dotNetobject.invokeMethodAsync("GotoPage", href);
        return false;
    });

}

function CheckRoute() {

    $(".navview-pane")
        .find("li")
        .removeClass("active");


    var ipath = location.pathname.indexOf("/", 1);
    var hash = ipath > 0 ? location.pathname.substr(0, ipath) : location.pathname;

    console.log(`ipath: ${location.pathname}`);
    console.log(`hash: ${hash}`);

    var target = hash === '/' ? 'index' : hash.substr(1);
    var link = $(".navview-menu a[href*='" + location.pathname + "']");
    var menu = link.closest("ul[data-role=dropdown]");
    var node = link.parent("li").addClass("active");

    if (menu.length > 0) {
        if (link.closest(".navview").hasClass('js-compact')) {
            Metro.getPlugin(menu, "dropdown").close();
        } else {
            Metro.getPlugin(menu, "dropdown").open();
        }
    }

}


var Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000
});

var messageService = {
    showNotifySuccess: (content, title) => {
        Toast.fire({
            icon: 'success',
            title: title,
            text: content
        })
    },
    yesNoMessage: (dotNetObject = null, _options = null) => {

        const options = Object.assign({
            title: "Confirme...",
            content: "Continuar con la acción?",
            callback: "",
            returnedObjectOnYes: null,
            returnedObjectOnNo: null,
            icon: "warning",
            confirmButtonText: 'Si, Continuar',
            cancelButtonText: 'No, Cancelar',
            confirmButtonClass: 'btn btn-danger m-1',
            cancelButtonClass: 'btn btn-info m-1'
        }, _options);

        return Swal.fire({
            title: options.title,
            html: options.content,
            icon: options.icon,
            showCancelButton: true,
            confirmButtonText: options.confirmButtonText,
            cancelButtonText: options.cancelButtonText,
            customClass: {
                confirmButton: options.confirmButtonClass,
                cancelButton: options.cancelButtonClass
            },
            buttonsStyling: false
        }).then(r => {
            var result = { Result: r.isConfirmed, ObjectResult: r.isConfirmed ? options.returnedObjectOnYes : options.returnedObjectOnNo };            
            return result;
        });
    }
};

//Metro.dialog.create({
//    title: options.title,
//    content: options.content,
//    clsDialog: options.clsDialog,
//    actions: [{
//        caption: "Si",
//        cls: "js-dialog-close alert",
//        onclick: () => {
//            console.log(options.returnedObjectOnYes)
//            resolve({ Result: true, ObjectResult: options.returnedObjectOnYes });
//        }
//    }, {
//        caption: "No",
//        cls: "js-dialog-close info",
//        onclick: () => {
//            console.log(options.returnedObjectOnNo)
//            resolve({ Result: false, ObjectResult: options.returnedObjectOnNo });
//        }
//    }]
//});


//return promise.then(r => {
//    dotNetObject.invokeMethodAsync(options.callback, r);
//    console.log(r);
//    return r;
//});

//    }
//}
