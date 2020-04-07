var updateEdit = "";

function getEntitlement1(style) {
    var colordrop = "ColorPop_" + "Drop_" + style;
    var colorValue = document.getElementsByName(colordrop);
    var selectedcolor = colorValue[0].defaultValue == "" & colorValue[0].value == "" ? "" : colorValue[0].defaultValue != "" ? colorValue[0].defaultValue : colorValue[0].value;
    if (style.includes(',')) {
        var stylerop = "styleDimDrp_" + style;
        var styleValue = document.getElementsByName(stylerop);
        var selectedStyle = styleValue[0].defaultValue == "" & styleValue[0].value == "" ? "" : styleValue[0].defaultValue != "" & styleValue[0].value != "" ? styleValue[0].value : styleValue[0].defaultValue != "" & styleValue[0].value == "" ? styleValue[0].defaultValue : "";
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': selectedStyle, 'ColorId': selectedcolor },
            success: function (response) {
                if (response != "") {
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                }
            },
            error: function (response) {

            }
        });
    }
    else {
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': style, 'ColorId': selectedcolor },
            success: function (response) {
                var data = document.getElementById("Entitlement");
                data.innerHTML = response.Result;
                Entitlement.Show();
            },
            error: function (response) {

            }
        });
    }
}
function getEntitlementDIMENSION(style, orgStyle) {
    if (style != "" && orgStyle != "") {
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': style, 'orgStyl': orgStyle },
            success: function (response) {
                if (response != "") {
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                }
            },
            error: function (response) {

            }
        });
    }
}
function getEntitlementonDemand(style) {
    var colordrop = "ColorDimview_" + "Drop_" + style;
    var colorValue = document.getElementsByName(colordrop);
    var selectedcolor = colorValue[0].defaultValue == "" & colorValue[0].value == "" ? "" : colorValue[0].defaultValue != "" ? colorValue[0].defaultValue : colorValue[0].value;
    if (style.includes(',')) {
        var stylerop = "styleDimviewDrp_" + style;
        var styleValue = document.getElementsByName(stylerop);
        var selectedStyle = styleValue[0].defaultValue == "" & styleValue[0].value == "" ? "" : styleValue[0].defaultValue != "" & styleValue[0].value != "" ? styleValue[0].value : styleValue[0].defaultValue != "" & styleValue[0].value == "" ? styleValue[0].defaultValue : "";
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': selectedStyle, 'ColorId': selectedcolor },
            success: function (response) {
                if (response != "") {
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                }
            },
            error: function (response) {

            }
        });
    }
    else {
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': style, 'ColorId': selectedcolor },
            success: function (response) {
                var data = document.getElementById("Entitlement");
                data.innerHTML = response.Result;
                Entitlement.Show();
            },
            error: function (response) {

            }
        });
    }
}

function getEntitlementDemand(style, error) {
    var colordrop = "ColorDimview_" + "Drop_" + style;
    var colorValue = document.getElementsByName(colordrop);
    var selectedcolor = colorValue[0].defaultValue == "" & colorValue[0].value == "" ? "" : colorValue[0].defaultValue != "" ? colorValue[0].defaultValue : colorValue[0].value;
    if (style.includes(',')) {
        var stylerop = "styleDimviewDrp_" + style;
        var styleValue = document.getElementsByName(stylerop);
        var selectedStyle = styleValue[0].defaultValue == "" & styleValue[0].value == "" ? "" : styleValue[0].defaultValue != "" & styleValue[0].value != "" ? styleValue[0].value : styleValue[0].defaultValue != "" & styleValue[0].value == "" ? styleValue[0].defaultValue : "";
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': style, 'ColorId': selectedcolor },
            success: function (response) {
                if (response != "") {
                    var errorMsg = "";
                    if (error == 1) {
                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result + errorMsg;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                }
            },
            error: function (response) {

            }
        });
    }
    else {
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': style, 'ColorId': selectedcolor },
            success: function (response) {
                var errorMsg = "";
                if (error == 1) {
                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                }
                var data = document.getElementById("Entitlement");
                data.innerHTML = response.Result + errorMsg;
                Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                Entitlement.Show();
            },
            error: function (response) {

            }
        });
    }
}

function getEntitlementDim(style, error) {
    var colordrop = "ColorPop_" + "Drop_" + style;
    var colorValue = document.getElementsByName(colordrop);
    var selectedcolor = colorValue[0].defaultValue == "" & colorValue[0].value == "" ? "" : colorValue[0].defaultValue != "" ? colorValue[0].defaultValue : colorValue[0].value;
    if (style.includes(',')) {
        var stylerop = "styleDimDrp_" + style;
        var styleValue = document.getElementsByName(stylerop);
        var selectedStyle = styleValue[0].defaultValue == "" & styleValue[0].value == "" ? "" : styleValue[0].defaultValue != "" & styleValue[0].value != "" ? styleValue[0].value : styleValue[0].defaultValue != "" & styleValue[0].value == "" ? styleValue[0].defaultValue : "";
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': style, 'ColorId': selectedcolor },
            success: function (response) {
                if (response != "") {
                    var errorMsg = "";
                    if (error == 1) {
                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result + errorMsg;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                }
            },
            error: function (response) {

            }
        });
    }
    else {
        $.ajax({
            url: "/Home/GetEntitlement",
            type: "POST",
            data: { 'StyleId': style, 'ColorId': selectedcolor },
            success: function (response) {
                var errorMsg = "";
                if (error == 1) {
                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                }
                var data = document.getElementById("Entitlement");
                data.innerHTML = response.Result + errorMsg;
                Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                Entitlement.Show();
            },
            error: function (response) {

            }
        });
    }
}



function getSelectedSizeSwatch(style, size, orgStyle) {
    var styleId_Val = style.includes(",") ? GetStyleIdSwatch(style, orgStyle) : style;

    if (size != "" && styleId_Val != "") {
        $.ajax({
            type: "POST",
            url: '/Home/GetPriceStats/',
            success: function (response) {
                if (response == "readonly") {
                    $.ajax({
                        type: "POST",
                        url: '/Home/GetPrice/',
                        data: { 'StyleID': styleId_Val, 'SizeId': size },
                        success: function (response) {
                            if (!response.includes("Login")) {
                                var priceId = "LbPrice" + style;
                                var price = document.getElementById(priceId);
                                price.innerHTML = "";
                                price.innerHTML = "<input class='form-control' id='LbPriceinput" + style + "' readonly  type=\"number\" min=\"1\" max=\"10000\" value='" + response + "'/>";
                            }
                            else {
                                window.location = "/User/Login/";
                            }
                        },
                        error: function (erdata) {
                        }
                    });
                }
                else if (response == "readwrite") {
                    $.ajax({
                        type: "POST",
                        url: '/Home/GetPrice/',
                        data: { 'StyleID': styleId_Val, 'SizeId': size },
                        success: function (response) {
                            if (!response.includes("Login")) {
                                var priceId = "LbPrice" + style;
                                var price = document.getElementById(priceId);
                                price.innerHTML = "";
                                price.innerHTML = "<input class='form-control' id='LbPriceinput" + style + "'    type=\"number\" min=\"1\" max=\"10000\" value='" + response + "'/>";
                            }
                            else {
                                window.location = "/User/Login/";
                            }
                        },
                        error: function (erdata) {
                        }
                    });
                }
            }
            , error: function (erd) {

            }
        });

    }
    else {
        alert("Please select the colorId first!");
        thisDrop = ASPxClientControl.GetControlCollection().GetByName(s.name);
        thisDrop.SetValue("");
    }
}

function getSelectedSizeDimSwatch(style, size) {
    var styleId_Val = style.includes(",") ? GetStyleId(style) : style;

    if (size != "" && styleId_Val != "") {

        $.ajax({
            type: "POST",
            url: '/Home/GetPrice/',
            data: { 'StyleID': styleId_Val, 'SizeId': size },
            success: function (response) {
                ;
                if (!response.includes("Login")) {
                    var priceId = "LbPrice1" + style;
                    var price = document.getElementById(priceId);
                    price.innerHTML = "";
                    price.innerHTML = response;
                }
                else {
                    window.location = "/User/Login/";
                }
            },
            error: function (erdata) {
            }
        });
    }
    else {
        alert("Please select the colorId first!");
        thisDrop = ASPxClientControl.GetControlCollection().GetByName(s.name);
        thisDrop.SetValue("");
    }
}

function getSelectedSizeDemandSwatch(style, size, orgStyle) {

    var styleId_Val = style.includes(",") ? GetStyleIdDemandSwatch(style, orgStyle) : style;
    //var sizeStyle = "swatch_DemandSize_" + style;
    //var sizeswatch = document.getElementsByName(sizeStyle);


    //for (var i = 0; i < sizeswatch.length; i++) {
    //    if (isNaN(size) == true || sizeswatch[i].value == size) {
    //        if (sizeswatch[i].checked == true) {
    //            size = sizeswatch[i].value;

    //        }
    //    }
    //}

    if (size != "" && styleId_Val != "") {
        $.ajax({
            type: "POST",
            url: '/Home/GetPriceStats/',
            success: function (response) {
                if (response == "readonly") {
                    $.ajax({
                        type: "POST",
                        url: '/Home/GetPrice/',
                        data: { 'StyleID': styleId_Val, 'SizeId': size },
                        success: function (response) {
                            ;
                            if (!response.includes("Login")) {
                                var priceId = "DimviewPriceinput1" + style;
                                var price = document.getElementById(priceId);
                                price.innerHTML = "";
                                price.innerHTML = "<input class='form-control' id='DimviewPriceinput" + styleId_Val + "' readonly type=\"number\" min=\"1\" max=\"10000\" value='" + response + "'/>";

                            }
                            else {
                                window.location = "/User/Login/";
                            }
                        },
                        error: function (erdata) {
                        }
                    });
                }
                else if (response == "readwrite") {
                    $.ajax({
                        type: "POST",
                        url: '/Home/GetPrice/',
                        data: { 'StyleID': styleId_Val, 'SizeId': size },
                        success: function (response) {
                            ;
                            if (!response.includes("Login")) {
                                var priceId = "DimviewPriceinput1" + style;
                                var price = document.getElementById(priceId);
                                price.innerHTML = "";
                                price.innerHTML = "<input class='form-control' id='DimviewPriceinput" + styleId_Val + "' readonly type=\"number\" min=\"1\" max=\"10000\" value='" + response + "'/>";

                            }
                            else {
                                window.location = "/User/Login/";
                            }
                        },
                        error: function (erdata) {
                        }
                    });
                }

            }
        });

    }
    else {
        alert("Please select the colorId first!");
        thisDrop = ASPxClientControl.GetControlCollection().GetByName(s.name);
        thisDrop.SetValue("");
    }
}

function getEntitlementSwatch(style, orgStyl, error) {
    var colorValue;
    var colorSwatchName = "swatch_Color_" + style;
    var colorSwatch = document.getElementsByName(colorSwatchName);
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    var selectedcolor = colorValue == undefined | colorValue == "" ? "" : colorValue;
    if (selectedcolor != "") {
        if (style.includes(',')) {
            var name = 'Swatch_Style_FieldSet_' + style;
            var fieldSet = document.getElementsByName(name);
            var selStyle;
            for (var i = 0; i < fieldSet[0].elements.length; i++) {
                if (fieldSet[0].elements[i].checked) {
                    selStyle = fieldSet[0].elements[i].value;
                }
            }
            $.ajax({
                url: "/Home/GetEntitlement",
                type: "POST",
                data: { 'StyleId': selStyle, 'ColorId': selectedcolor, 'orgStyl': orgStyl },
                success: function (response) {
                    if (response != "") {
                        var errorMsg = "";
                        if (error == 1) {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                        }
                        var data = document.getElementById("Entitlement");
                        data.innerHTML = response.Result + errorMsg;
                        Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                        Entitlement.Show();
                    }
                },
                error: function (response) {

                }
            });
        }
        else {
            $.ajax({
                url: "/Home/GetEntitlement",
                type: "POST",
                data: { 'StyleId': style, 'ColorId': selectedcolor, 'orgStyl': style },
                success: function (response) {
                    var errorMsg = "";
                    if (error == 1) {
                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result + errorMsg;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                },
                error: function (response) {

                }
            });
        }
    } else {
        alert("Please select colour");
    }
}

function getEntitlementDimSwatch(style, error) {
    var colorValue;
    var colorSwatchName = "swatch_DimColor_" + style;
    var colorSwatch = document.getElementsByName(colorSwatchName);
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    var selectedcolor = colorValue == undefined | colorValue == "" ? "" : colorValue;
    if (selectedcolor != "") {
        if (style.includes(',')) {
            var stylerop = "styleDimDrp_" + style;
            var styleValue = document.getElementsByName(stylerop);
            var selectedStyle = styleValue[0].defaultValue == "" & styleValue[0].value == "" ? "" : styleValue[0].defaultValue != "" & styleValue[0].value != "" ? styleValue[0].value : styleValue[0].defaultValue != "" & styleValue[0].value == "" ? styleValue[0].defaultValue : "";
            $.ajax({
                url: "/Home/GetEntitlement",
                type: "POST",
                data: { 'StyleId': selectedStyle, 'ColorId': selectedcolor },
                success: function (response) {
                    if (response != "") {
                        var errorMsg = "";
                        if (error == 1) {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                        }
                        var data = document.getElementById("Entitlement");
                        data.innerHTML = response.Result + errorMsg;
                        Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                        Entitlement.Show();
                    }
                },
                error: function (response) {

                }
            });
        }
        else {
            $.ajax({
                url: "/Home/GetEntitlement",
                type: "POST",
                data: { 'StyleId': style, 'ColorId': selectedcolor },
                success: function (response) {
                    var errorMsg = "";
                    if (error == 1) {
                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result + errorMsg;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                },
                error: function (response) {

                }
            });
        }
    } else {
        alert("Please select the color");
    }
}

function getEntitlementDemandSwatch(style, orgStyl, error) {
    var colorValue;
    var colorSwatchName = "swatch_DemandColor_" + style;
    var colorSwatch = document.getElementsByName(colorSwatchName);
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    var selectedcolor = colorValue == undefined | colorValue == "" ? "" : colorValue;
    if (selectedcolor != "") {
        if (style.includes(',')) {
            if (style.includes(',')) {
                var name = 'Swatch_DemandStyle_FieldSet_' + style;
                var fieldSet = document.getElementsByName(name);
                var selStyle;
                for (var i = 0; i < fieldSet[0].elements.length; i++) {
                    if (fieldSet[0].elements[i].checked) {
                        selStyle = fieldSet[0].elements[i].value;
                    }
                }
            }

            $.ajax({
                url: "/Home/GetEntitlement",
                type: "POST",
                data: { 'StyleId': selStyle, 'ColorId': selectedcolor, 'orgStyl': orgStyl },
                success: function (response) {
                    if (response != "") {
                        var data = document.getElementById("Entitlement");
                        var errorMsg = "";
                        if (error == 1) {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                        }
                        data.innerHTML = response.Result + errorMsg;
                        Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                        Entitlement.Show();
                    }
                },
                error: function (response) {

                }
            });
        }
        else {
            $.ajax({
                url: "/Home/GetEntitlement",
                type: "POST",
                data: { 'StyleId': style, 'ColorId': selectedcolor, 'orgStyl': orgStyl },
                success: function (response) {
                    var data = document.getElementById("Entitlement");
                    var errorMsg = "";
                    if (error == 1) {
                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>"
                    }
                    data.innerHTML = response.Result + errorMsg;
                    Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    Entitlement.Show();
                },
                error: function (response) {

                }
            });
        }
    } else {
        alert("Please select the color!");
    }
}

function addTocartSwatch(s, e) {

    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");

    var stylearr = s.name.split('_');
    var description = "";
    var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var colorValue;
    var sizeValue;
    var colorSwatchName = "swatch_Color_" + stylearr[1];
    var colorSwatch = document.getElementsByName(colorSwatchName);
    var sizeSwatchName = "swatch_Size_" + stylearr[1];
    var sizeSwatch = document.getElementsByName(sizeSwatchName);
    var reasonName = "CmbReason_" + stylearr[1];
    var reasonControl = document.getElementsByName(reasonName);
    var reason;
    if (reasonControl.length > 0) {
        reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;
    }
    if (sizeSwatch.length > 1) {
        for (var i = 0; i < sizeSwatch.length; i++) {
            if (sizeSwatch[i].checked) {
                sizeValue = sizeSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (sizeSwatch[0].checked) {
            sizeValue = sizeSwatch[0].offsetParent.innerText;
        }
    }
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    size = sizeValue != undefined && sizeValue != "" ? sizeValue : "";
    color = colorValue != undefined && colorValue != "" ? colorValue : "";

    if (stylearr[1].includes(',')) {
        var name = 'Swatch_Style_FieldSet_' + stylearr[1];
        var fieldSet = document.getElementsByName(name);
        var selStyle;
        for (var i = 0; i < fieldSet[0].elements.length; i++) {
            if (fieldSet[0].elements[i].checked) {
                selStyle = fieldSet[0].elements[i].value;
            }
        }
        sStyle = selStyle;
        descStyle = stylearr[1].split(',');
    }
    else {
        sStyle = stylearr[1];
    }
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = document.getElementsByName("spinEdit_" + stylearr[1]);
    var descriptionDiv = document.getElementById("LbDescription" + desc);
    description = descriptionDiv.innerHTML;
    var priceId = document.getElementById("LbPriceinput" + stylearr[1]);
    price = priceId != undefined && priceId != null ? priceId.value : "0";
    qty = Spin[0].value;
    var clsName = "reqData" + stylearr[1];
    var reqdatatxt = "reqdatatxt" + stylearr[1];
    var reqData = document.getElementsByClassName(clsName);
    if (reqData[0].style.display != "none") {
        var reqtxt = document.getElementsByClassName(reqdatatxt);
        if (description != "" && price != "" && size != "" && color != "" && qty != "" && qty != "0" && reqtxt[0].value != "") {
            if (stylearr[2] != "") {
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            loadPopup.Show();

                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'reqData1': reqtxt[0].value, 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        loadPopup.Hide();
                                        myFunction("Added to cart..!");
                                        //myFunction("Added to cart..!");  ;
                                    }
                                    else {
                                        loadPopup.Hide();
                                        myFunction("Try again..!");
                                        //alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    myFunction("Try again..!");
                                    //alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        myFunction("Added to cart..!"); ("Try again!");
                    }
                });
            }
            else {
                loadPopup.Show();
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        myFunction("Added to cart..!");
                                    }
                                    else {
                                        loadPopup.Hide();
                                        alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        alert("Try again!");
                    }
                });
            }

        }
        else {
            if (price == "" || price == null || price == undefined) {
                alert("Please choose a size");
            }
            else if (size == "" || size == null || size == undefined) {
                alert("Please choose a Size");
            }
            else if (color == "" || color == null || color == undefined) {
                alert("Please choose a Colour");
            }
            else if (qty == "" || qty == "0" || qty == null || qty == undefined) {
                alert("Quantity should be greater than 0");
            }
            else if (reqtxt[0].value == "") {
                alert("Please select Required leg length");
            }
        }
    }
    else {
        if (description != "" && price != "" && size != "" && color != "" && qty != "" && qty != "0") {
            if (stylearr[2] != "") {
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            loadPopup.Show();

                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        loadPopup.Hide();
                                        myFunction("Added to cart..!");
                                        //myFunction("Added to cart..!");  ;
                                    }
                                    else {
                                        loadPopup.Hide();
                                        myFunction("Try again..!");
                                        //alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    myFunction("Try again..!");
                                    //alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        myFunction("Added to cart..!"); ("Try again!");
                    }
                });
            }
            else {
                loadPopup.Show();
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        myFunction("Added to cart..!");
                                    }
                                    else {
                                        loadPopup.Hide();
                                        alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        alert("Try again!");
                    }
                });
            }

        }
        else {
            if (price == "" || price == null || undefined) {
                alert("Please choose a size");
            }
            else if (size == "" || size == null || size == undefined) {
                alert("Please choose a Size");
            }
            else if (color == "" || color == null || color == undefined) {
                alert("Please choose a Colour");
            }
            else if (qty == "" || qty == "0" || qty == null || qty == undefined) {
                alert("Quantity should be greater than 0");
            }
            else if (reqtxt[0].value == "") {
                alert("Please select Required leg length");
            }
        }
    }
}

function addTocartDimSwatch(s, e) {

    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");

    var stylearr = s.name.split('_');
    var description = "";
    var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var colorValue;
    var sizeValue;
    var colorSwatchName = "swatch_DimColor_" + stylearr[1];
    var colorSwatch = document.getElementsByName(colorSwatchName);
    var sizeSwatchName = "swatch_DimSize_" + stylearr[1];
    var sizeSwatch = document.getElementsByName(sizeSwatchName);
    var reasonName = "CmbReasonDim_" + stylearr[1];
    var reasonControl = document.getElementsByName(reasonName);
    var reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;

    if (sizeSwatch.length > 1) {
        for (var i = 0; i < sizeSwatch.length; i++) {
            if (sizeSwatch[i].checked) {
                sizeValue = sizeSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (sizeSwatch[0].checked) {
            sizeValue = sizeSwatch[0].offsetParent.innerText;
        }
    }
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    size = sizeValue != undefined | sizeValue != "" ? sizeValue : "";
    color = colorValue != undefined | colorValue != "" ? colorValue : "";

    if (stylearr[1].includes(',')) {
        var data = ASPxClientControl.GetControlCollection().GetByName("styleDimDrp_" + stylearr[1]);
        sStyle = data.lastSuccessText;
        descStyle = stylearr[1].split(',');
    }
    else {
        sStyle = stylearr[1];
    }
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = ASPxClientControl.GetControlCollection().GetByName("spinEditDim_" + stylearr[1]);
    description = document.getElementById("LbDescription1" + desc).innerHTML;
    price = document.getElementById("LbPrice1" + stylearr[1]).innerHTML;
    qty = Spin.lastValue;
    if (description != "" && price != "" && size != "" && color != "" && qty != "" && qty != "0") {
        if (stylearr[2] != "") {
            $.ajax({
                url: "/Home/GetBtnStatus/",
                type: "POST",
                data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty },
                success: function (response) {
                    debugger;
                    if (response == "enabled" | (reason != "" && reason != undefined)) {
                        loadPopup.Show();

                        $.ajax({
                            url: "/Home/Addtocart/",
                            type: "POST",
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'reason': reason },
                            success: function (response) {
                                if (response != "") {
                                    $("#CartwidCount").html("");
                                    $("#CartwidCount").html(response);
                                    loadPopup.Hide();
                                    myFunction("Added to cart..!");
                                }
                                else {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            },
                            error: function () {
                                loadPopup.Hide();
                                alert("Try again!");
                            }
                        })
                    }
                    else {
                        //  document.getElementById("ErrorMessage").style.display = 'block';
                        loadPopup.Hide();
                        getEntitlementDimSwatch(stylearr[1], 1);

                    }
                },
                error: function () {
                    loadPopup.Hide();
                    alert("Try again!");
                }
            });
        }
        else {
            loadPopup.Show();
            $.ajax({
                url: "/Home/GetBtnStatus/",
                type: "POST",
                data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty },
                success: function (response) {
                    debugger;
                    if (response == "enabled" | (reason != "" && reason != undefined)) {
                        $.ajax({
                            url: "/Home/Addtocart/",
                            type: "POST",
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'reason': reason },
                            success: function (response) {
                                if (response != "") {
                                    $("#CartwidCount").html("");
                                    $("#CartwidCount").html(response);
                                    myFunction("Added to cart..!");
                                }
                                else {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            },
                            error: function () {
                                loadPopup.Hide();
                                alert("Try again!");
                            }
                        })
                    }
                    else {
                        // document.getElementById("ErrorMessage").style.display = 'block';
                        loadPopup.Hide();
                        getEntitlementDimSwatch(stylearr[1], 1);

                    }
                },
                error: function () {
                    loadPopup.Hide();
                    alert("Try again!");
                }
            });
        }

    }
    else {
        if (price == "" || price == null || undefined) {
            alert("Please choose a size");
        }
        else if (size == "" || size == null || size == undefined) {
            alert("Please choose a Size");
        }
        else if (color == "" || color == null || color == undefined) {
            alert("Please choose a Colour");
        }
        else if (qty == "" || qty == "0" || qty == null || qty == undefined) {
            alert("Quantity should be greater than 0");
        }
        else if (reqtxt[0].value == "") {
            alert("Please select Required leg length");
        }
    }
}

function addTocartDemandSwatch(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");

    var stylearr = s.name.split('_');
    var description = "";
    var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var colorValue;
    var sizeValue;
    var colorSwatchName = "swatch_DemandColor_" + stylearr[1];
    var colorSwatch = document.getElementsByName(colorSwatchName);
    var sizeSwatchName = "swatch_DemandSize_" + stylearr[1];
    var sizeSwatch = document.getElementsByName(sizeSwatchName);
    var reasonName = "CmbDemandReason_" + stylearr[1];
    var reasonControl = document.getElementsByName(reasonName);
    var reason;
    if (reasonControl.length > 0) {
        reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;
    }
    if (sizeSwatch.length > 1) {
        for (var i = 0; i < sizeSwatch.length; i++) {
            if (sizeSwatch[i].checked) {
                sizeValue = sizeSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (sizeSwatch[0].checked) {
            sizeValue = sizeSwatch[0].offsetParent.innerText;
        }
    }
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    size = sizeValue != undefined | sizeValue != "" ? sizeValue : "";
    color = colorValue != undefined | colorValue != "" ? colorValue : "";

    if (stylearr[1].includes(',')) {
        var name = 'Swatch_DemandStyle_FieldSet_' + stylearr[1];
        var fieldSet = document.getElementsByName(name);
        var selStyle;
        for (var i = 0; i < fieldSet[0].elements.length; i++) {
            if (fieldSet[0].elements[i].checked) {
                selStyle = fieldSet[0].elements[i].value;
            }
        }
        sStyle = selStyle;
        descStyle = stylearr[1].split(',');
    }
    else {
        sStyle = stylearr[1];
    }
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = document.getElementsByName("spinDemandEdit_" + stylearr[1]);
    var priceId = document.getElementById("DimviewPriceinput" + stylearr[1]);
    description = document.getElementById("LbdemandDescription" + desc).innerHTML;
    price = priceId != undefined && priceId != null ? priceId.value : "0";
    qty = Spin[0].value;
    var clsName = "reqDatadim" + stylearr[1];
    var reqdatatxt = "reqdatatxtdim" + stylearr[1];
    var reqData = document.getElementsByClassName(clsName);
    if (reqData[0].style.display != "none") {
        var reqtxt = document.getElementsByClassName(reqdatatxt);
        if (description != "" && price != "" && size != undefined && price != undefined && color != undefined && size != "" && color != "" && qty != "" && qty != "0" && reqtxt[0].value != "") {
            if (stylearr[2] != "") {
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            loadPopup.Show();

                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reqData1': reqtxt[0].value, 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        loadPopup.Hide();
                                        myFunction("Added to cart..!");
                                    }
                                    else {
                                        loadPopup.Hide();
                                        alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementDemandSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        alert("Try again!");
                    }
                });
            }
            else {
                loadPopup.Show();
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        myFunction("Added to cart..!");
                                    }
                                    else {
                                        loadPopup.Hide();
                                        alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementDemandSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        alert("Try again!");
                    }
                });
            }

        }
        else {
            if (price == "" || price == null || undefined) {
                alert("Please choose a size");
            }
            else if (size == "" || size == null || size == undefined) {
                alert("Please choose a Size");
            }
            else if (color == "" || color == null || color == undefined) {
                alert("Please choose a Colour");
            }
            else if (qty == "" || qty == "0" || qty == null || qty == undefined) {
                alert("Quantity should be greater than 0");
            }
            else if (reqtxt[0].value == "") {
                alert("Please select Required leg length");
            }
        }
    }
    else {
        if (description != "" && price != "" && size != undefined && price != undefined && color != undefined && size != "" && color != "" && qty != "" && qty != "0") {
            if (stylearr[2] != "") {
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            loadPopup.Show();

                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        loadPopup.Hide();
                                        myFunction("Added to cart..!");
                                    }
                                    else {
                                        loadPopup.Hide();
                                        alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementDemandSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        alert("Try again!");
                    }
                });
            }
            else {
                loadPopup.Show();
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        myFunction("Added to cart..!");
                                    }
                                    else {
                                        loadPopup.Hide();
                                        alert("Try again!");
                                    }
                                },
                                error: function () {
                                    loadPopup.Hide();
                                    alert("Try again!");
                                }
                            })
                        }
                        else {
                            // document.getElementById("ErrorMessage").style.display = 'block';
                            loadPopup.Hide();
                            getEntitlementDemandSwatch(stylearr[1], stylearr[3], 1);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        alert("Try again!");
                    }
                });
            }

        }
        else {
            if (price == "" || price == null || undefined) {
                alert("Please choose a size");
            }
            else if (size == "" || size == null || size == undefined) {
                alert("Please choose a Size");
            }
            else if (color == "" || color == null || color == undefined) {
                alert("Please choose a Colour");
            }
            else if (qty == "" || qty == "0" || qty == null || qty == undefined) {
                alert("Quantity should be greater than 0");
            }
            else if (reqtxt[0].value == "") {
                alert("Please select Required leg length");
            }
        }
    }
}
function GetDrpResulTemplateModelSwatch(stle, selStyle, orgStyle) {
    var style_nam = stle;

    var colorFieldsetName = "Swatch_ColorTemplate_FieldSet_" + style_nam;
    var sizeFieldsetName = "Swatch_Size_FieldSet_" + style_nam;
    var colorFieldset = document.getElementsByName(colorFieldsetName);
    var sizeFieldset = document.getElementsByName(sizeFieldsetName);
    var clrContent = "";
    var sizContent = "";
    var description = document.getElementById("LbDescription" + style_nam.split(',')[0]);
    var colorSwatchName = "Swatch_ColorTemplate_" + stle;
    var colorSwatch = document.getElementsByName(colorSwatchName);
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    description.innerHTML = "";
    var url = "/Home/DrpResultModel";
    $.ajax({
        url: url,
        type: "POST",
        data: { 'styleId': selStyle, 'color': colorValue },
        success: function (response) {
            if (response != "") {

                $.ajax({
                    url: "/Home/GetLastSize/",
                    type: "POST",
                    data: { 'style': selStyle },
                    success: function (resp) {
                        if (resp != "") {

                            description.innerHTML = response.Description;

                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\" min=\"0\" onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + orgStyle + "')\" type =\"number\" class=\"BulkSizeBox" + response.PriceList[i].Size + "_" + style_nam + " form-control\" style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input id='" + stle + "_" + response.PriceList[i].Size + "' type =\"number\" placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }

                                    }
                                    else {
                                        if (response.SizeList[i] == resp.Size) {
                                            sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatchTemplate_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeTemplateSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                        }
                                        else {
                                            sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatchTemplate_Size_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeTemplateSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                        }
                                    }

                                }
                                else {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div class='col-md-4  BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" placeholder='Quantity'   min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" id='" + stle + "_" + response.PriceList[i].Size + "' placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }
                                    }
                                    else {
                                        sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatchTemplate_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeTemplateSwatch('" + style_nam + "','" + response.SizeList[i].Size + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                            }
                            var cnt = "";
                            if (response.isManpack == false) {
                                if (response.isBulk == false) {
                                    if (response.HasReqData == false) {
                                        cnt = cnt + "<div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center></div> <div class='col-md-4'><center>Quantity</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center> </div><div class='col-md-4'><center>Quantity</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center> </div><div class='col-md-4'><center>Quantity</center></div></div></div> <br /><hr />";
                                    }
                                    else {
                                        cnt = cnt + "<div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center></div> <div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center> </div><div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center> </div><div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><br /><hr />";
                                    }
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent != "" ? clrContent : colorFieldset[0].innerHTML;
                            sizeFieldset[0].innerHTML = cnt + sizContent;
                            var priceId = "LbTemplatePrice" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? resp.price == "" ? "" : resp.price : response.Price;
                            $.ajax({
                                type: "POST",
                                url: "/Home/GetReqData/",
                                data: { 'StyleID': selStyle },
                                success: function (response) {
                                    if (response != "") {
                                        var clsName = "reqData" + stle;
                                        var headClsName = "reqDataHeading" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'block';
                                    }
                                    else {
                                        var clsName = "reqData" + stle;
                                        var headClsName = "reqDataHeading" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'none';
                                    }
                                }
                            });
                        } else {
                            description.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.SizeList.length ; i++) {

                                if (response.SizeList.length > 1) {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\"  onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + stylearr[1] + "')\" type =\"number\" class=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + " form-control\"  min=\"0\"  style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" id='" + stle + "_" + response.PriceList[i].Size + "' placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }
                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatchTemplate_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                                else {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\"  onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + stylearr[1] + "')\" type =\"number\" class=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + " form-control\"  min=\"0\"  style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_template_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\"  onblur=\"GetBulkPrice('" + response.SizeList[i] + "','" + style_nam + "','" + stylearr[1] + "')\" type =\"number\" class=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + " form-control\"  min=\"0\"  id='" + stle + "_" + response.PriceList[i].Size + "'  style=\"width:100%; text-align: center;  \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                            }
                                        }
                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatchTemplate_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'  onclick=\"getSelectedSizeTemplateSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = cnt + sizContent;
                            var priceId = "LbTemplatePrice" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? "" : response.Price;
                            $.ajax({
                                type: "POST",
                                url: "/Home/GetReqData/",
                                data: { 'StyleID': styleId_Val },
                                success: function (response) {
                                    if (response != "") {
                                        var clsName = "reqData" + style;
                                        var headClsName = "reqDataHeading" + style;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'block';
                                    }
                                    else {
                                        var clsName = "reqData" + style;
                                        var headClsName = "reqDataHeading" + style;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'none';
                                    }
                                }
                            });
                        }
                    }
                })

            }
        },
        error: function () {

        }
    });
}

function GetDrpResultModelSwatch(stle, selStyle, orgStyle) {
    var style_nam = stle;

    var colorFieldsetName = "Swatch_Color_FieldSet_" + style_nam;
    var sizeFieldsetName = "Swatch_Size_FieldSet_" + style_nam;
    var colorFieldset = document.getElementsByName(colorFieldsetName);
    var sizeFieldset = document.getElementsByName(sizeFieldsetName);
    var clrContent = "";
    var sizContent = "";
    var description = document.getElementById("LbDescription" + style_nam.split(',')[0]);
    var colorSwatchName = "swatch_Color_" + stle;
    var colorSwatch = document.getElementsByName(colorSwatchName);
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    description.innerHTML = "";
    var url = "/Home/DrpResultModel";
    $.ajax({
        url: url,
        type: "POST",
        data: { 'styleId': selStyle, 'color': colorValue },
        success: function (response) {
            if (response != "") {

                $.ajax({
                    url: "/Home/GetLastSize/",
                    type: "POST",
                    data: { 'style': selStyle },
                    success: function (resp) {
                        if (resp != "") {

                            description.innerHTML = response.Description;

                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\" min=\"0\" onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + orgStyle + "')\" type =\"number\" class=\"BulkSizeBox" + response.PriceList[i].Size + "_" + style_nam + " form-control\" style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input id='" + stle + "_" + response.PriceList[i].Size + "' type =\"number\" placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }

                                    }
                                    else {
                                        if (response.SizeList[i] == resp.Size) {
                                            sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                        }
                                        else {
                                            sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                        }
                                    }

                                }
                                else {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div class='col-md-4  BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" placeholder='Quantity'   min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" id='" + stle + "_" + response.PriceList[i].Size + "' placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }
                                    }
                                    else {
                                        sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i].Size + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                            }
                            var cnt = "";
                            if (response.isManpack == false) {
                                if (response.isBulk == false) {
                                    if (response.HasReqData == false) {
                                        cnt = cnt + "<div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center></div> <div class='col-md-4'><center>Quantity</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center> </div><div class='col-md-4'><center>Quantity</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center> </div><div class='col-md-4'><center>Quantity</center></div></div></div> <br /><hr />";
                                    }
                                    else {
                                        cnt = cnt + "<div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center></div> <div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center> </div><div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center> </div><div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><br /><hr />";
                                    }
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent != "" ? clrContent : colorFieldset[0].innerHTML;
                            sizeFieldset[0].innerHTML = cnt + sizContent;
                            var priceId = "LbPrice" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? resp.price == "" ? "" : resp.price : response.Price;
                            $.ajax({
                                type: "POST",
                                url: "/Home/GetReqData/",
                                data: { 'StyleID': selStyle },
                                success: function (response) {
                                    if (response != "") {
                                        var clsName = "reqData" + stle;
                                        var headClsName = "reqDataHeading" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'block';
                                    }
                                    else {
                                        var clsName = "reqData" + stle;
                                        var headClsName = "reqDataHeading" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'none';
                                    }
                                }
                            });
                        } else {
                            description.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.SizeList.length ; i++) {

                                if (response.SizeList.length > 1) {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\"  onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + stylearr[1] + "')\" type =\"number\" class=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + " form-control\"  min=\"0\"  style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" id='" + stle + "_" + response.PriceList[i].Size + "' placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }
                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                                else {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\"  onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + stylearr[1] + "')\" type =\"number\" class=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + " form-control\"  min=\"0\"  style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity' id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input   id='ReqData_" + stle + "_" + response.PriceList[i].Size + "'  type =\"text\" placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + "\"  onblur=\"GetBulkPrice('" + response.SizeList[i] + "','" + style_nam + "','" + stylearr[1] + "')\" type =\"number\" class=\"BulkSizeBox_" + response.PriceList[i].Size + "_" + style_nam + " form-control\"  min=\"0\"  id='" + stle + "_" + response.PriceList[i].Size + "'  style=\"width:100%; text-align: center;  \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                            }
                                        }
                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'  onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = cnt + sizContent;
                            var priceId = "LbPrice" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? "" : response.Price;
                            $.ajax({
                                type: "POST",
                                url: "/Home/GetReqData/",
                                data: { 'StyleID': styleId_Val },
                                success: function (response) {
                                    if (response != "") {
                                        var clsName = "reqData" + style;
                                        var headClsName = "reqDataHeading" + style;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'block';
                                    }
                                    else {
                                        var clsName = "reqData" + style;
                                        var headClsName = "reqDataHeading" + style;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'none';
                                    }
                                }
                            });
                        }
                    }
                })

            }
        },
        error: function () {

        }
    });
}

function GetDrpResultModelDemandSwatch(stle, selStyle, orgStyle) {
    var style_nam = stle;
    //var stylearr = style_nam.split('_');
    //var selStyle = s.GetSelectedItem(style_nam).value;
    var colorFieldsetName = "Swatch_DemColor_FieldSet_" + style_nam;
    var sizeFieldsetName = "Swatch_DemSize_FieldSet_" + style_nam;
    var colorFieldset = document.getElementsByName(colorFieldsetName);
    var sizeFieldset = document.getElementsByName(sizeFieldsetName);
    var clrContent = "";
    var sizContent = "";
    var description = document.getElementById("LbdemandDescription" + style_nam.split(',')[0]);
    description.innerHTML = "";
    var url = "/Home/DrpResultModel";
    var colorSwatchName = "swatch_DemandColor_" + stle;
    var colorSwatch = document.getElementsByName(colorSwatchName);
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    $.ajax({
        url: url,
        type: "POST",
        data: { 'styleId': selStyle, 'color': colorValue },
        success: function (response) {
            if (response != "") {
                $.ajax({
                    url: "/Home/GetLastSize/",
                    type: "POST",
                    data: { 'style': selStyle },
                    success: function (resp) {
                        if (resp != "") {

                            description.innerHTML = response.Description;

                            sizeFieldset[0].innerHTML = "";
                            //for (var i = 0; i < response.ColorList.length ; i++) {
                            //    if (response.ColorList.length > 1) {
                            //        colorFieldset[0].innerHTML = "";
                            //        clrContent = clrContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedColorSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                            //    }
                            //    else {
                            //        colorFieldset[0].innerHTML = "";
                            //        clrContent = clrContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedColorSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                            //    }
                            //}
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            if (response.PriceList[i].Size == resp.Size) {

                                                sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBoxDim_" + response.PriceList[i] + "_" + style_nam + "\" min=\"0\" onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + orgStyle + "')\" type =\"number\" class=\"BulkSizeBoxDim_" + response.PriceList[i].Size + "_" + style_nam + " form-control\" style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                            }
                                            else {
                                                sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBoxDim_" + response.PriceList[i] + "_" + style_nam + "\" min=\"0\" onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + orgStyle + "')\" type =\"number\" class=\"BulkSizeBoxDim_" + response.PriceList[i].Size + "_" + style_nam + " form-control\" style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                            }
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" placeholder='Quantity'  id='" + stle + "_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }

                                    }
                                    else {
                                        if (response.SizeList[i] == resp.Size) {
                                            sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" class='' value='" + response.SizeList[i] + "' checked=\"checked\"/><span class='spanner1'  onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                            //sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                        }
                                        else {
                                            sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" class='' value='" + response.SizeList[i] + "'  /><span class='spanner1'  onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                            //sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" value='blue'/><span class='spanner1'><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                        }
                                    }
                                }
                                else {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBoxDim_" + response.PriceList[i] + "_" + style_nam + "\" min=\"0\" onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + orgStyle + "')\" type =\"number\" class=\"BulkSizeBoxDim_" + response.PriceList[i].Size + "_" + style_nam + " form-control\" style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";

                                        } else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" id='" + stle + "_" + response.PriceList[i].Size + "'  placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }
                                    }
                                    else {
                                        sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                            }
                            var cnt = "";
                            if (response.isManpack == false) {
                                if (response.isBulk == false) {
                                    if (response.HasReqData == false) {
                                        cnt = cnt + "<div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center></div> <div class='col-md-4'><center>Quantity</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center> </div><div class='col-md-4'><center>Quantity</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-4'><center>Size</center></div><div class='col-md-4'><center>Price</center> </div><div class='col-md-4'><center>Quantity</center></div></div></div> <br /><hr />";
                                    }
                                    else {
                                        cnt = cnt + "<div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center></div> <div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center> </div><div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><div class='col-md-4' style='margin-bottom:15px;'><div class='row'><div class='col-md-3'><center>Size</center></div><div class='col-md-3'><center>Price</center> </div><div class='col-md-3'><center>Quantity</center></div><div class='col-md-3'><center>ReqData</center></div></div></div><br /><hr />";
                                    }
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent != "" ? clrContent : colorFieldset[0].innerHTML;
                            sizeFieldset[0].innerHTML = cnt + sizContent;
                            var priceId = "DimviewPriceinput" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? resp.price == "" ? "" : resp.price : response.Price;
                            $.ajax({
                                type: "POST",
                                url: "/Home/GetReqData/",
                                data: { 'StyleID': selStyle },
                                success: function (response) {
                                    if (response != "") {
                                        var clsName = "reqDatadim" + stle;
                                        var headClsName = "reqDataHeadingdim" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'block';
                                    }
                                    else {
                                        var clsName = "reqDatadim" + stle;
                                        var headClsName = "reqDataHeadingdim" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'none';
                                    }
                                }
                            });

                        } else {
                            description.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            //for (var i = 0; i < response.ColorList.length ; i++) {
                            //    if (response.ColorList.length > 1) {
                            //        clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                            //    }
                            //    else {
                            //        clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                            //    }
                            //}
                            for (var i = 0; i < response.SizeList.length ; i++) {

                                if (response.SizeList.length > 1) {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBoxDim_" + response.PriceList[i] + "_" + style_nam + "\" min=\"0\" onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + orgStyle + "')\" type =\"number\" class=\"BulkSizeBoxDim_" + response.PriceList[i].Size + "_" + style_nam + " form-control\" style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }

                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                                else {
                                    if (response.isManpack == false) {
                                        if (response.isBulk) {
                                            sizContent = sizContent + "<div  class='col-md-1'><center><p>" + response.PriceList[i].Size + "</p><input  id=\"BulkSizeBoxDim_" + response.PriceList[i] + "_" + style_nam + "\" min=\"0\" onblur=\"GetBulkPrice('" + response.PriceList[i].Size + "','" + style_nam + "','" + orgStyle + "')\" type =\"number\" class=\"BulkSizeBoxDim_" + response.PriceList[i].Size + "_" + style_nam + " form-control\" style=\"width:100%; text-align: center; \"/><div style=\"margin-top:10px;margin-bottom:10px;\"><p><span id='LbPrice_" + style_nam + "_" + response.PriceList[i].Size + "'>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</span></p></div></center></div> ";
                                        }
                                        else {
                                            if (response.HasReqData) {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                        }

                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = cnt + sizContent;
                            var priceId = "DimviewPriceinput" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? "" : response.Price;
                            $.ajax({
                                type: "POST",
                                url: "/Home/GetReqData/",
                                data: { 'StyleID': selStyle },
                                success: function (response) {
                                    if (response != "") {
                                        var clsName = "reqDatadim" + stle;
                                        var headClsName = "reqDataHeadingdim" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'block';
                                    }
                                    else {
                                        var clsName = "reqDatadim" + stle;
                                        var headClsName = "reqDataHeadingdim" + stle;
                                        var stylVal = document.getElementsByClassName(clsName);
                                        var headVal = document.getElementsByClassName(headClsName);
                                        headVal[0].innerHTML = response;
                                        stylVal[0].style.display = 'none';
                                    }
                                }
                            });
                        }
                    }
                })

            }
        },
        error: function () {
        }
    });
}


function GetDimDrpResultModelSwatch(s, e) {
    var style_nam = s.name.includes("styleDimDrp_") ? s.name.replace("styleDimDrp_", "") : s.name;
    var selStyle = s.GetSelectedItem(style_nam).value;
    var colorFieldsetName = "Swatch_DimColor_FieldSet_" + style_nam;
    var sizeFieldsetName = "Swatch_DimSize_FieldSet_" + style_nam;
    var colorFieldset = document.getElementsByName(colorFieldsetName);
    var sizeFieldset = document.getElementsByName(sizeFieldsetName);
    var clrContent = "";
    var sizContent = "";
    var desc = "LbDescription1" + style_nam;
    var url = "/Home/DrpResultModel/";
    $.ajax({
        url: url,
        type: "POST",
        data: { 'styleId': selStyle },
        success: function (response) {
            if (response != "") {
                $.ajax({
                    url: "/Home/GetLastSize/",
                    type: "POST",
                    data: { 'style': selStyle },
                    success: function (resp) {
                        if (resp != "") {
                            desc.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" value='blue'/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    if (response.SizeList[i] == resp.Size) {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDimSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeDimSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                                else {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDimSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "LbPrice1" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? resp.price == "" ? "" : resp.price : response.Price;

                        } else {
                            desc.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" value='blue'/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    clrContent = clrContent + "<label><input type='radio' id='radio' name=\"swatch_Color_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDimSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDimSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "LbPrice1" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? "" : response.Price;
                        }
                    }
                })

            }
        },
        error: function () {

        }
    });
}

function GetDemandDrpResultModelSwatch(s, e) {
    var style_nam = s.name.includes("styleDimviewDrp_") ? s.name.replace("styleDimviewDrp_", "") : s.name;
    var selStyle = s.GetSelectedItem(style_nam).value;
    var colorFieldsetName = "Swatch_DemColor_FieldSet_" + style_nam;
    var sizeFieldsetName = "Swatch_DemSize_FieldSet_" + style_nam;
    var colorFieldset = document.getElementsByName(colorFieldsetName);
    var sizeFieldset = document.getElementsByName(sizeFieldsetName);
    var clrContent = "";
    var sizContent = "";
    var desc = "DimviewDescription" + style_nam;
    var url = "/Home/DrpResultModel";
    $.ajax({
        url: url,
        type: "POST",
        data: { 'styleId': selStyle },
        success: function (response) {
            if (response != "") {

                $.ajax({
                    url: "/Home/GetLastSize/",
                    type: "POST",
                    data: { 'style': selStyle },
                    success: function (resp) {
                        if (resp != "") {
                            desc.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" value='blue'/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    if (response.SizeList[i] == resp.Size) {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                    else {
                                        sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                                else {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "DimviewPriceinput" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? resp.price == "" ? "" : resp.price : response.Price;

                        } else {
                            desc.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" value='blue'/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "DimviewPriceinput" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? "" : response.Price;
                        }
                    }
                })

            }
        },
        error: function () {

        }
    });
}

function GetStyleIdSwatch(data, orgStyle) {
    //var StyleId = ASPxClientControl.GetControlCollection().GetByName("styleDrp_" + data + "_" + orgStyle);
    var name = "Swatch_Style_FieldSet_" + data;
    var StyleId = document.getElementsByName(name);
    for (var i = 0; i <= StyleId[0].elements.length; i++) {
        if (StyleId[0].elements[i].checked) {
            return StyleId[0].elements[i].value;
        }

    }
}

function GetStyleIdDemandSwatch(data, orgStyle) {
    //var StyleId = ASPxClientControl.GetControlCollection().GetByName("styleDrp_" + data + "_" + orgStyle);
    var name = "Swatch_DemandStyle_FieldSet_" + data;
    var StyleId = document.getElementsByName(name);
    for (var i = 0; i <= StyleId[0].elements.length; i++) {
        if (StyleId[0].elements[i].checked) {
            return StyleId[0].elements[i].value;
        }

    }
}

function CreateTemplateOrder(EmployeeId, UcodesName, EmployeeName) {
    var popup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var ctrlName = UcodesName.split('_');
    var ucodeCmb = ASPxClientControl.GetControlCollection().GetByName("checkComboBox_" + ctrlName[1]);
    if (ucodeCmb.lastSuccessText != "" && ucodeCmb.lastSuccessText != undefined && ucodeCmb.lastSuccessText != null) {
        if (EmployeeId != "") {
            popup.Show();
            $.ajax({
                type: "Post",
                url: "/Employee/GotoCardTemplate/",
                data: { 'EmployeeId': EmployeeId, 'Template': ucodeCmb.lastSuccessText, 'EmpName': EmployeeName },
                success: function (response) {
                    if (response != null) {
                        popup.Hide();
                        window.location = response;
                    }
                }
            });
        }

    } else {
        alert("Select Uniforms first!")
    }
}

function getSelectedTemplateSize(s, e) {
    var selectedSize = "";
    var data1 = s.name.split("_");
    selectedSize = s.GetSelectedItem().value;
    if (selectedSize != "") {

        $.ajax({
            type: "POST",
            url: "/Home/GetPrice/",
            data: { 'StyleID': data1[2], 'SizeId': selectedSize },
            success: function (response) {
                if (!response.includes("Login")) {
                    var priceId = "LbTemplatePrice" + data1[2];
                    var price = document.getElementById(priceId);
                    price.innerHTML = "";
                    price.innerHTML = response;
                }
                else {
                    window.location = "/User/Login/";
                }
            },
            error: function (erdata) {
            }
        });
    }
    else {
        alert("Please select the colorId first!");
        thisDrop = ASPxClientControl.GetControlCollection().GetByName(s.name);
        thisDrop.SetValue("");
    }
}

function getSelectedSizeTemplateSwatch(style, size) {
    var selectedSize = size; var selectedStyl = "";
    var styleNames = "Swatch_Style_" + style;
    var styles = document.getElementsByName(styleNames);
    if (style.includes(",")) {
        for (var i = 0; i < styles.length ; i++) {
            if (styles[i].checked) {
                selectedStyl = styles[i].value;
            }
        }
    }
    else {
        selectedStyl = style;
    }
    if (selectedSize != "") {

        $.ajax({
            type: "POST",
            url: "/Home/GetPrice/",
            data: { 'StyleID': selectedStyl, 'SizeId': selectedSize },
            success: function (response) {
                if (!response.includes("Login")) {
                    var priceId = "LbTemplatePrice" + style;
                    var price = document.getElementById(priceId);
                    price.innerHTML = "";
                    price.innerHTML = response;
                }
                else {
                    window.location = "/User/Login/";
                }
            },
            error: function (erdata) {
            }
        });
    }
    else {
        alert("Please select the color  first!");
        thisDrop = ASPxClientControl.GetControlCollection().GetByName(s.name);
        thisDrop.SetValue("");
    }
}

function addTocartTemplateSwatch(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var stylearr = s.name.split('_');
    var description = "";
    var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var colorValue;
    var sizeValue;
    var colorSwatchName = "Swatch_ColorTemplate_" + stylearr[1];
    var colorSwatch = document.getElementsByName(colorSwatchName);
    var sizeSwatchName = "swatchTemplate_Size_" + stylearr[1];
    var sizeSwatch = document.getElementsByName(sizeSwatchName);
    if (sizeSwatch.length > 1) {
        for (var i = 0; i < sizeSwatch.length; i++) {
            if (sizeSwatch[i].checked) {
                sizeValue = sizeSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (sizeSwatch[0].checked) {
            sizeValue = sizeSwatch[0].offsetParent.innerText;
        }
    }

    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }

    size = sizeValue != undefined & sizeValue != "" ? sizeValue : "";
    color = colorValue != undefined & colorValue != "" ? colorValue : "";
    if (stylearr[1].includes(',')) {
        var name = 'Swatch_Style_FieldSet_' + stylearr[1];
        var fieldSet = document.getElementsByName(name);
        var selStyle;
        for (var i = 0; i < fieldSet[0].elements.length; i++) {
            if (fieldSet[0].elements[i].checked) {
                selStyle = fieldSet[0].elements[i].value;
            }
        }
        sStyle = selStyle;
        descStyle = stylearr[1].split(',');
    }
    else {
        sStyle = stylearr[1];
    }

    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = "spinEdit_" + stylearr[1];
    var qty1 = document.getElementsByName(Spin);
    description = document.getElementById("LbDescription" + stylearr[1].split(',')[0]).innerHTML;
    price = document.getElementById("LbTemplatePrice" + stylearr[1]).innerHTML;
    qty = qty1[0].value;
    if (description != "" && price != "" && size != "" && color != "" && qty != "" && qty != "0") {
        loadPopup.Show();
        $.ajax({
            url: "/Home/AddToCart/",
            type: "Post",
            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle },
            success: function (response) {
                if (response != "") {
                    $("#CartwidCount").html("");
                    $("#CartwidCount").html(response);
                    loadPopup.Hide();
                    myFunction("Added to cart..!");;
                }
                else {
                    loadPopup.Hide();
                    alert("Try again!");
                }

            },
            error: function (response) {
            }
        });
    }
    else {
        if (description == "" | description == null) {
            alert("Please select a Description");
        }
        else if (price == "" | price == null) {

            alert("Please select a Price");
        }
        else if (size == "" | size == null) {

            alert("Please select a Size");
        } else if (color == "" | color == null) {

            alert("Please select a Color");
        } else if (qty == "" | qty == null) {

            alert("Please select a Qty");
        }
        else if (sStyle == "" | sStyle == null) {

            alert("Please select a Style");
        }
    }
}

function addTocartTemplate(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var stylearr = s.name.split('_');
    var description = "";
    var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var sizName = "Size_Template_" + stylearr[1];
    var sizedrp = document.getElementsByName(sizName);
    var name = "Color_Template_" + stylearr[1];
    var colorDrp = document.getElementsByName(name);
    var Spin = ASPxClientControl.GetControlCollection().GetByName("spinEdit_" + stylearr[1]);
    sStyle = stylearr[1];
    description = document.getElementById("LbDescription" + desc).innerHTML;
    price = document.getElementById("LbTemplatePrice" + stylearr[1]).innerHTML;
    size = sizedrp[0].value == undefined ? sizedrp[0].defaultValue : sizedrp[0].value;
    color = colorDrp[0].value == undefined ? colorDrp[0].defaultValue : colorDrp[0].value;
    qty = Spin.lastValue;
    if (description != "" && price != "" && size != "" && color != "" && qty != "" && qty != "0") {
        loadPopup.Show();
        $.ajax({
            url: "/Home/Addtocart/",
            type: "POST",
            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle },
            success: function (response) {
                if (response != "") {
                    $("#CartwidCount").html("");
                    $("#CartwidCount").html(response);
                    loadPopup.Hide();
                    myFunction("Added to cart..!");;
                }
                else {
                    loadPopup.Hide();
                    alert("Try again!");
                }
            },
            error: function () {
                loadPopup.Hide();
                alert("Try again!");
            }
        });
    }
    else {
        if (description == "" | description == null) {
            alert("Please select a Description");
        }
        else if (price == "" | price == null) {

            alert("Please select a Price");
        }
        else if (size == "" | size == null) {

            alert("Please select a Size");
        } else if (color == "" | color == null) {

            alert("Please select a Colour");
        } else if (qty == "" | qty == null) {

            alert("Please select a Quantity");
        }
        else if (sStyle == "" | sStyle == null) {

            alert("Please select a Style");
        }
    }
}

function CancelEmployee() {
    var EditPop = ASPxClientControl.GetControlCollection().GetByName("CreateEditPop");
    EditPop.Hide();
}

function CreateNewEmployee() {
    var popup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    popup.Show();
    $.ajax({
        url: "/Employee/CreateNewEmployee/",
        type: "GET",
        success: function (response) {
            if (response != "") {
                if (!response.includes("Login")) {
                    var EditPop = ASPxClientControl.GetControlCollection().GetByName("CreateEditPop");
                    EditPop.SetHeaderText("Create");
                    $("#EditLayout").html("");
                    $("#EditLayout").html(response); popup.Hide();
                    EditPop.Show();
                    // MVCxClientUtils.FinalizeCallback();
                }
                else {
                    window.location = "/User/Login";
                }
            }
            else {
                alert("Something went wrong!");
            }
        },
        error: function () {

        }

    });
}

function UpdateEmployee(s, e) {
    var EditPop = ASPxClientControl.GetControlCollection().GetByName("CreateEditPop");
    var empID = ASPxClientControl.GetControlCollection().GetByName("editEmpId");
    var frstName = ASPxClientControl.GetControlCollection().GetByName("editEmpFirstName");
    var lstName = ASPxClientControl.GetControlCollection().GetByName("editEmpLastName");
    var dept = ASPxClientControl.GetControlCollection().GetByName("editDepartment");
    var selUcode;
    var hoursCmb = ASPxClientControl.GetControlCollection().GetByName("hoursCmb");
    var hoursDept = ASPxClientControl.GetControlCollection().GetByName("hoursDEPT");
    var hoursNo = ASPxClientControl.GetControlCollection().GetByName("hoursNo");
    if (s.name != "UpdateBtn_Template") {
        selUcode = ASPxClientControl.GetControlCollection().GetByName("checkComboEdit");
    }
    var date = new Date().toISOString();
    var strtDate = ASPxClientControl.GetControlCollection().GetByName("editStartDate");
    var endDate = ASPxClientControl.GetControlCollection().GetByName("editStartDate");
    var isAct = ASPxClientControl.GetControlCollection().GetByName("editEmpIsActive");
    var address = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var addressVal = address != null ? address.GetValue() : "";
    if (s.name != "UpdateBtn_Template") {
        if ((hoursCmb == undefined || hoursCmb == null) && (hoursDept == undefined || hoursDept == null)) {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & selUcode.lastChangedValue != null) {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & selUcode.lastChangedValue.trim() != "") {
                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal };
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EditEmployee1/",
                        data: data1,
                        success: function (response) {
                            if (response == "success") {
                                alert("Successfully updated!");
                                EditPop.Hide();
                                window.location.reload();
                            }
                            else if (response == "Validation") {
                                alert("Please fill all data");
                            }
                        }
                    });
                }
            }
            else {
                alert("Please fill all details");
            }
        }
        else if ((hoursCmb == undefined || hoursCmb == null) || (hoursDept != undefined || hoursDept != null)) {
            var hrsDept = hoursDept.GetValue();
            var hrsNo = hoursNo.GetValue();
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hrsDept != null) {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & hrsDept.trim() != "") {
                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal };
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EditEmployee1/",
                        data: data1,
                        success: function (response) {
                            if (response == "success") {
                                alert("Successfully updated!");
                                EditPop.Hide();
                                window.location.reload();
                            }
                            else if (response == "Validation") {
                                alert("Please fill all data");
                            }

                        }
                    });
                }
            }
            else {
                alert("Please fill all details");
            }
        }
        else {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hoursCmb.lastChangedValue != null) {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & hoursCmb.lastChangedValue.trim() != "") {
                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hrsCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal };
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EditEmployee1/",
                        data: data1,
                        success: function (response) {
                            if (response == "success") {
                                alert("Successfully updated!");
                                EditPop.Hide();
                                window.location.reload();
                            }
                            else if (response == "Validation") {
                                alert("Please fill all data");
                            }

                        }
                    });
                }
            }
            else {
                alert("Please fill all details");
            }
        }
    }
    else {
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null) {
            if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "") {
                var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal };
                $.ajax({
                    type: "POST",
                    url: "/Employee/EditEmployee1/",
                    data: data1,
                    success: function (response) {
                        if (response == "success") {
                            alert("Successfully updated!");
                            EditPop.Hide();
                            window.location.reload();
                        }
                        else if (response == "Validation") {
                            alert("Please fill all data");
                        }
                    }
                });
            }
        }
        else {
            alert("Please fill all details");
        }
    }

}

function CreateEmployee(s, e) {
    var EditPop = ASPxClientControl.GetControlCollection().GetByName("CreateEditPop");
    var empID = ASPxClientControl.GetControlCollection().GetByName("editEmpId");
    var frstName = ASPxClientControl.GetControlCollection().GetByName("editEmpFirstName");
    var lstName = ASPxClientControl.GetControlCollection().GetByName("editEmpLastName");
    var dept = ASPxClientControl.GetControlCollection().GetByName("editDepartment");
    var selUcode;
    var hoursCmb = ASPxClientControl.GetControlCollection().GetByName("hoursCmb");
    var hoursDept = ASPxClientControl.GetControlCollection().GetByName("hoursDEPT");
    var hoursNo = ASPxClientControl.GetControlCollection().GetByName("hoursNo");
    if (s.name != "CreateBtn_Template") {
        selUcode = ASPxClientControl.GetControlCollection().GetByName("checkComboEdit");
    }
    var strtDate = ASPxClientControl.GetControlCollection().GetByName("editStartDate");
    var endDate = ASPxClientControl.GetControlCollection().GetByName("editStartDate");
    var isAct = ASPxClientControl.GetControlCollection().GetByName("editEmpIsActive");
    var address = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var empMapper = ASPxClientControl.GetControlCollection().GetByName("empMapper");
    var isMapped = empMapper == null | empMapper == undefined ? false : empMapper.GetValue();
    if (s.name != "CreateBtn_Template") {
        if ((hoursCmb == undefined || hoursCmb == null) && (hoursDept == undefined || hoursDept == null)) {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & selUcode.lastChangedValue != null) {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & selUcode.lastChangedValue.trim() != "") {

                    var data1;
                    var date = new Date().toISOString();
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EmployeeIdValidation/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (response) {
                            if (response == "Success") {
                                if (isAct.previousValue == false) {
                                    if (confirm("Do you want to set the employee Active")) {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped };
                                        $.ajax({
                                            type: "POST",
                                            url: "/Employee/CreateNewEmployee/",
                                            data: data1,
                                            success: function (response) {
                                                if (response == "success") {
                                                    alert("Successfully created employee!");
                                                    EditPop.Hide();
                                                    window.location.reload();
                                                }
                                                else {

                                                }
                                            },
                                            error: function (response) {
                                            }
                                        });
                                    }
                                    else {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                        $.ajax({
                                            type: "POST",
                                            url: "/Employee/CreateNewEmployee/",
                                            data: data1,
                                            success: function (response) {
                                                if (response == "success") {
                                                    alert("Successfully created employee!");
                                                    EditPop.Hide();
                                                    window.location.reload();
                                                }
                                                else {

                                                }
                                            },
                                            error: function (response) {
                                            }
                                        });
                                    }

                                }
                                else {
                                    data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                    $.ajax({
                                        type: "POST",
                                        url: "/Employee/CreateNewEmployee/",
                                        data: data1,
                                        success: function (response) {
                                            if (response == "success") {
                                                alert("Successfully created employee!");
                                                EditPop.Hide();
                                                window.location.reload();
                                            }
                                            else {

                                            }
                                        },
                                        error: function (response) {
                                        }
                                    });
                                }
                            }
                            else if (response == "") {
                                alert("The Employee id already registered please select different employee id");
                            }
                            else {
                                alert(response);
                            }
                        }
                    });
                    //$.ajax({
                    //    type: "POST",
                    //    url: "/Employee/EditEmployee/",
                    //    data: data1,
                    //    success: function (response) {
                    //        if (response == "success") {
                    //            alert("Successfully updated!");
                    //            EditPop.Hide();
                    //        }
                    //        else if (response == "Validation") {
                    //            alert("Please fill all data");
                    //        }
                    //    }
                    //});


                }
            }
            else {
                alert("Please fill all details");
            }
        }
        else if ((hoursCmb == undefined || hoursCmb == null) && (hoursDept != undefined || hoursDept != null)) {
            var hrsDept = hoursDept.GetValue();
            var hrsNo = hoursNo.GetValue();
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hoursDept.lastChangedValue != null & hrsDept != null) {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & hrsDept != "") {

                    var data1;
                    var date = new Date().toISOString();
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EmployeeIdValidation/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (response) {
                            if (response == "Success") {
                                if (isAct.previousValue == false) {
                                    if (confirm("Do you want to set the employee Active")) {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped };
                                        $.ajax({
                                            type: "POST",
                                            url: "/Employee/CreateNewEmployee/",
                                            data: data1,
                                            success: function (response) {
                                                if (response == "success") {
                                                    alert("Successfully created employee!");
                                                    EditPop.Hide();
                                                    window.location.reload();
                                                }
                                                else {

                                                }
                                            },
                                            error: function (response) {
                                            }
                                        });
                                    }
                                    else {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                        $.ajax({
                                            type: "POST",
                                            url: "/Employee/CreateNewEmployee/",
                                            data: data1,
                                            success: function (response) {
                                                if (response == "success") {
                                                    alert("Successfully created employee!");
                                                    EditPop.Hide();
                                                    window.location.reload();
                                                }
                                                else {

                                                }
                                            },
                                            error: function (response) {
                                            }
                                        });
                                    }

                                }
                                else {
                                    data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                    $.ajax({
                                        type: "POST",
                                        url: "/Employee/CreateNewEmployee/",
                                        data: data1,
                                        success: function (response) {
                                            if (response == "success") {
                                                alert("Successfully created employee!");
                                                EditPop.Hide();
                                                window.location.reload();
                                            }
                                            else {

                                            }
                                        },
                                        error: function (response) {
                                        }
                                    });
                                }
                            }
                            else if (response == "") {
                                alert("The Employee id already registered please select different employee id");
                            }
                            else {
                                alert(response);
                            }
                        }
                    });
                }
            }
            else {
                alert("Please fill all details");
            }
        }
        else {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hoursCmb.lastChangedValue != null) {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & hoursCmb.lastChangedValue.trim() != "") {

                    var data1;
                    var date = new Date().toISOString();
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EmployeeIdValidation/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (response) {
                            if (response == "Success") {
                                if (isAct.previousValue == false) {
                                    if (confirm("Do you want to set the employee Active")) {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped };
                                        $.ajax({
                                            type: "POST",
                                            url: "/Employee/CreateNewEmployee/",
                                            data: data1,
                                            success: function (response) {
                                                if (response == "success") {
                                                    alert("Successfully created employee!");
                                                    EditPop.Hide();
                                                    window.location.reload();
                                                }
                                                else {

                                                }
                                            },
                                            error: function (response) {
                                            }
                                        });
                                    }
                                    else {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                        $.ajax({
                                            type: "POST",
                                            url: "/Employee/CreateNewEmployee/",
                                            data: data1,
                                            success: function (response) {
                                                if (response == "success") {
                                                    alert("Successfully created employee!");
                                                    EditPop.Hide();
                                                    window.location.reload();
                                                }
                                                else {

                                                }
                                            },
                                            error: function (response) {
                                            }
                                        });
                                    }

                                }
                                else {
                                    data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                    $.ajax({
                                        type: "POST",
                                        url: "/Employee/CreateNewEmployee/",
                                        data: data1,
                                        success: function (response) {
                                            if (response == "success") {
                                                alert("Successfully created employee!");
                                                EditPop.Hide();
                                                window.location.reload();
                                            }
                                            else {

                                            }
                                        },
                                        error: function (response) {
                                        }
                                    });
                                }
                            }
                            else if (response == "") {
                                alert("The Employee id already registered please select different employee id");
                            }
                            else {
                                alert(response);
                            }
                        }
                    });
                    //$.ajax({
                    //    type: "POST",
                    //    url: "/Employee/EditEmployee/",
                    //    data: data1,
                    //    success: function (response) {
                    //        if (response == "success") {
                    //            alert("Successfully updated!");
                    //            EditPop.Hide();
                    //        }
                    //        else if (response == "Validation") {
                    //            alert("Please fill all data");
                    //        }
                    //    }
                    //});


                }
            }
            else {
                alert("Please fill all details");
            }
        }
    }
    else {
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null) {
            if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "") {

                var data1;
                var date = new Date();
                $.ajax({
                    type: "POST",
                    url: "/Employee/EmployeeIdValidation/",
                    data: { 'empId': empID.lastChangedValue.trim() },
                    success: function (response) {
                        if (response == "Success") {
                            if (isAct.previousValue == false) {
                                if (confirm("Do you want to set the employee Active")) {
                                    data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true };
                                    $.ajax({
                                        type: "POST",
                                        url: "/Employee/CreateNewEmployee/",
                                        data: data1,
                                        success: function (response) {
                                            if (response == "success") {
                                                alert("Successfully created employee!");
                                                EditPop.Hide();
                                                window.location.reload();
                                            }
                                            else {

                                            }
                                        },
                                        error: function (response) {
                                        }
                                    });
                                }
                                else {
                                    data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                    $.ajax({
                                        type: "POST",
                                        url: "/Employee/CreateNewEmployee/",
                                        data: data1,
                                        success: function (response) {
                                            if (response == "success") {
                                                alert("Successfully created employee!");
                                                EditPop.Hide();
                                                window.location.reload();
                                            }
                                            else {

                                            }
                                        },
                                        error: function (response) {
                                        }
                                    });
                                }

                            }
                            else {
                                data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue };
                                $.ajax({
                                    type: "POST",
                                    url: "/Employee/CreateNewEmployee/",
                                    data: data1,
                                    success: function (response) {
                                        if (response == "success") {
                                            alert("Successfully created employee!");
                                            EditPop.Hide();
                                            window.location.reload();
                                        }
                                        else {

                                        }
                                    },
                                    error: function (response) {
                                    }
                                });
                            }
                        }
                        else if (response == "") {
                            alert("The Employee id already registered please select different employee id");
                        }
                        else {
                            alert(response);
                        }
                    }
                });
                //$.ajax({
                //    type: "POST",
                //    url: "/Employee/EditEmployee/",
                //    data: data1,
                //    success: function (response) {
                //        if (response == "success") {
                //            alert("Successfully updated!");
                //            EditPop.Hide();
                //        }
                //        else if (response == "Validation") {
                //            alert("Please fill all data");
                //        }
                //    }
                //});

            }
        }
        else {
            alert("Please fill all details");
        }
    }

}

function EditEmployee(empId) {
    var popup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    popup.Show();
    if (empId != "") {
        $.ajax({
            url: "/Employee/EditEmployee/",
            type: "GET",
            data: { 'empId': empId },
            success: function (response) {
                if (response != "") {
                    if (!response.includes("Login")) {
                        var EditPop = ASPxClientControl.GetControlCollection().GetByName("CreateEditPop");
                        EditPop.SetHeaderText("Edit");
                        $("#EditLayout").html("");
                        $("#EditLayout").html(response); popup.Hide();
                        EditPop.Show();
                    }
                    else {
                        window.location = "/User/Login";
                    }
                }
                else {
                    alert("Something went wrong!");
                }
            },
            error: function () {

            }

        });
    }
}

function updateTextEdit(s, e) {
    var thisChk = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var selectedItems = thisChk.GetSelectedItems();
    var split = s.name.split('_');
    var thisCmb = ASPxClientControl.GetControlCollection().GetByName("checkComboEdit");
    thisCmb.SetText(getSelectedItemsText(selectedItems));
}

function HideCmbEdit(s, e) {
    var thisCmb = ASPxClientControl.GetControlCollection().GetByName("checkComboEdit");
    // thisCmb.SetText(getSelectedItemsText(selectedItems));
    thisCmb.HideDropDown();
}

function synchronizeListBoxValues(s, e) {
    var thisCmb = ASPxClientControl.GetControlCollection().GetByName(s.name);
    thisCmb.UnselectAll();
    var texts = dropDown.GetText().split(textSeparator);
    var values = getValuesByTexts(texts);
    checkListBox.SelectValues(values);
    updateText(); // for remove non-existing texts
}

function getSelectedItemsText(items) {
    var texts = [];
    for (var i = 0; i < items.length; i++)
        texts.push(items[i].text);
    return texts.join(textSeparator);
}

function getValuesByTexts(texts) {
    var actualValues = [];
    var item;
    for (var i = 0; i < texts.length; i++) {
        item = checkListBox.FindItemByText(texts[i]);
        if (item != null)
            actualValues.push(item.value);
    }
    return actualValues;
}

function filterresults(s, e) {
    var tXt = s.GetText();
    var card = ASPxClientControl.GetControlCollection().GetByName("CardView");
    card.PerformCallback({ filterText: tXt });
}

function plus(name) {
    var valuee = document.getElementsByName(name);
    var curVale = parseInt(valuee[0].value);
    var currentVal = curVale == null | curVale == undefined ? parseInt($('input[name=' + name + ']').val()) : curVale;
    if (!isNaN(currentVal)) {
        // Increment
        document.getElementsByName(name)[0].value = currentVal + 1;
        //$('input[name=' + fieldName + ']').val(currentVal + 1);
    } else {
        // Otherwise put a 0 there
        document.getElementsByName(name)[0].value = 0;
    }
}

function minus(name) {

    var valuee = document.getElementsByName(name);
    var curVale = parseInt(valuee[0].value);
    // Get its current value
    var currentVal = curVale == null | curVale == undefined ? parseInt($('input[name=' + name + ']').val()) : curVale;
    // If it isn't undefined or its greater than 0
    if (!isNaN(currentVal) && currentVal > 1) {
        // Decrement one
        document.getElementsByName(name)[0].value = currentVal - 1;
    } else {
        // Otherwise put a 0 there
        if (currentVal != 1) {
            document.getElementsByName(name)[0].value = 0;
        }
    }
}

jQuery(document).ready(function () {
    // This button will increment the value
    $('.qtyplus').click(function (e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        fieldName = $(this).attr('field');
        // Get its current value
        var valuee = document.getElementsByName(fieldName);
        var curVale = parseInt(valuee[0].value);
        var currentVal = curVale == null | curVale == undefined ? parseInt($('input[name=' + fieldName + ']').val()) : curVale;
        // If is not undefined
        if (!isNaN(currentVal)) {
            // Increment
            document.getElementsByName(fieldName)[0].value = currentVal + 1;
            //$('input[name=' + fieldName + ']').val(currentVal + 1);
        } else {
            // Otherwise put a 0 there
            document.getElementsByName(fieldName)[0].value = 0;
        }
    });
    // This button will decrement the value till 0
    $(".qtyminus").click(function (e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        fieldName = $(this).attr('field');
        var valuee = document.getElementsByName(fieldName);
        var curVale = parseInt(valuee[0].value);
        // Get its current value
        var currentVal = curVale == null | curVale == undefined ? parseInt($('input[name=' + fieldName + ']').val()) : curVale;
        // If it isn't undefined or its greater than 0
        if (!isNaN(currentVal) && currentVal > 1) {
            // Decrement one
            document.getElementsByName(fieldName)[0].value = currentVal - 1;
        } else {
            // Otherwise put a 0 there
            if (currentVal != 1) {
                document.getElementsByName(fieldName)[0].value = 0;
            }
        }
    });

});

function getAssemblySwatch(style) {
    var name = 'Swatch_Style_FieldSet_' + style;
    var fieldSet = document.getElementsByName(name);
    var selStyle;
    for (var i = 0; i < fieldSet[0].elements.length; i++) {
        if (fieldSet[0].elements[i].checked) {
            selStyle = fieldSet[0].elements[i].value;
        }
    }
    var popup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    popup.Show();
    var name = $("#AssemblyDiv").val();
    var assemblyPopUp = ASPxClientControl.GetControlCollection().GetByName(name);
    $.ajax({
        type: "POST",
        url: "/Home/AssemblyInfo/",
        data: { 'styleId': selStyle },
        success: function (response) {
            ;
            if (response != "") {
                try {
                    var s = document.getElementById("AssemblyInfo");
                    s.innerHTML = response;
                    //$("#AssemblyInfo1").html(response);
                    popup.Hide();
                    AssemblyInformation.Show();
                }
                catch (err) {
                    $("#AssemblyInfo").html("");
                    $("#AssemblyInfo1").html(response);
                    popup.Hide();
                    AssemblyInformation.Show();
                }

            }
        },
        error: function (erdata) {

        }
    });

}

function myFunction(msg) {
    var x = document.getElementById("snackbar");
    x.innerHTML = msg;
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}

function openNav() {

    document.getElementById("mySidebar").style.width = "600px";
    //document.getElementById("main").style.marginLeft = "500px";
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    //document.getElementById("main").style.marginLeft = "0";
}

function GetEmpGrid() {
    var empId = ASPxClientControl.GetControlCollection().GetByName("FilterEmployeeId");
    var firstName = ASPxClientControl.GetControlCollection().GetByName("FilterEmpFirstName");
    var roles = ASPxClientControl.GetControlCollection().GetByName("FilterRoles");
    var dept = ASPxClientControl.GetControlCollection().GetByName("FilterDepartment");
    var ucodes = ASPxClientControl.GetControlCollection().GetByName("FilterEmpUcodes");
    //var address = ASPxClientControl.GetControlCollection().GetByName("FilterAddress");
    //var startDate = ASPxClientControl.GetControlCollection().GetByName("FilterDateEdit");
    //var ucodeDesc = ASPxClientControl.GetControlCollection().GetByName("FilterUcodeDesc");
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var empId1 = "";
    var firstName1 = "";
    var roles1 = "";
    var dept1 = "";
    var ucodes1 = "";
    if (empId != null) {
        empId1 = empId.GetValue();
    } if (firstName != null) {
        firstName1 = firstName.GetValue();
    } if (roles != null) {
        roles1 = roles.GetValue();
    } if (dept != null) {
        dept1 = dept.GetValue();
    } if (ucodes != null) {
        ucodes1 = ucodes.GetValue();
    }


    if (empId1 != "" | firstName1 != "" | roles1 != "" | dept1 != "" | ucodes1 != "") {
        $.ajax({
            url: "/Employee/EmployeeGridViewPartial/",
            type: "POST",
            data: { 'txtUcode': ucodes1, 'txtCDepartment': dept1, 'txtRole': roles1, 'txtEmpNo': empId1, 'txtName': firstName1 },
            success: function (response) {
                if (response != "") {
                    closeNav();
                    loadPopup.Hide();
                    var EmployeeGrid = document.getElementById("EmployeeGridViewPartial");
                    EmployeeGrid.innerHTML = response;
                    MVCxClientUtils.FinalizeCallback();
                }
            }
        });
    }
    else {
        loadPopup.Hide();
    }
}

function GetAllEmps() {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    $.ajax({
        url: "/Employee/EmployeeGridViewPartial/",
        type: "POST",
        success: function (response) {
            if (response != "" && !response.includes("Login")) {
                var empId = ASPxClientControl.GetControlCollection().GetByName("FilterEmployeeId");
                var firstName = ASPxClientControl.GetControlCollection().GetByName("FilterEmpFirstName");
                var roles = ASPxClientControl.GetControlCollection().GetByName("FilterRoles");
                var dept = ASPxClientControl.GetControlCollection().GetByName("FilterDepartment");
                var ucodes = ASPxClientControl.GetControlCollection().GetByName("FilterEmpUcodes");
                if (empId != null) {
                    empId.SetValue("");
                } if (firstName != null) {
                    firstName.SetValue("");
                } if (roles != null) {
                    roles.SetValue("");
                } if (dept != null) {
                    dept.SetValue("");
                } if (ucodes != null) {
                    ucodes.SetValue("");
                }
                closeNav();
                loadPopup.Hide();
                var EmployeeGrid = document.getElementById("EmployeeGridViewPartial");
                EmployeeGrid.innerHTML = response;
                MVCxClientUtils.FinalizeCallback();
            }
            else {
                window.location = "/User/Login";
            }
        }
    });
}

function GetClrImg(style) {
    var data = style.split('-');
    var divImg = "DivImg" + data[0];
    $.ajax({
        url: "/Home/GetClrImg/",
        type: "POST",
        data: { 'style': style },
        success: function (response) {
            if (response != "") {
                var imgDiv = document.getElementById(divImg);
                imgDiv.innerHTML = "";
                imgDiv.innerHTML = response;
            }
            else {

            }
        }
    });
}

function GetClrDemImg(style) {
    var data = style.split('-');
    var divImg = "DivImgDem" + data[0];
    $.ajax({
        url: "/Home/GetClrImg/",
        type: "POST",
        data: { 'style': style },
        success: function (response) {
            if (response != "") {
                var imgDiv = document.getElementById(divImg);
                imgDiv.innerHTML = "";
                imgDiv.innerHTML = response;
            }
            else {

            }
        }
    });
}

function FillAlldeliveryfields(s, e) {
    var addDescription = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var address1 = ASPxClientControl.GetControlCollection().GetByName("Address1");
    var address2 = ASPxClientControl.GetControlCollection().GetByName("Address2");
    var address3 = ASPxClientControl.GetControlCollection().GetByName("Address3");
    var city = ASPxClientControl.GetControlCollection().GetByName("City");
    var postCode = ASPxClientControl.GetControlCollection().GetByName("PostCode");

    var custRef = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var descAddId = parseInt(addDescription.GetValue());
    var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox == null ? "" : commentBox.GetValue();
    $.ajax({
        url: "/Basket/FillAllAddress/",
        type: "POST",
        data: { 'descAddId': descAddId, 'comment': comment },
        success: function (resp) {
            address1.SetValue(resp.BusAdd.Address1);
            address2.SetValue(resp.BusAdd.Address2);
            address3.SetValue(resp.BusAdd.Address3);
            city.SetValue(resp.BusAdd.City);
            postCode.SetValue(resp.BusAdd.PostCode);

            custRef.SetValue(resp.custRef);
            nomCode.SetValue(resp.nomCode);
        }
    });
}

function FillAllFields(s, e) {
    var addDescription = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var address1 = ASPxClientControl.GetControlCollection().GetByName("EmpAddress1");
    var address2 = ASPxClientControl.GetControlCollection().GetByName("EmpAddress2");
    var address3 = ASPxClientControl.GetControlCollection().GetByName("EmpAddress3");
    var city = ASPxClientControl.GetControlCollection().GetByName("EmpCity");
    var postCode = ASPxClientControl.GetControlCollection().GetByName("EmpPostCode");

    var descAddId = parseInt(addDescription.GetValue());
    $.ajax({
        url: "/Employee/FillAllAddress/",
        type: "POST",
        data: { 'descAddId': descAddId },
        success: function (resp) {
            address1.SetValue(resp[0].Address1);
            address2.SetValue(resp[0].Address2);
            address3.SetValue(resp[0].Address3);
            city.SetValue(resp[0].City);
            postCode.SetValue(resp[0].PostCode);

        }
    });
}

function FillCustRefandDeliveryFields(s, e) {
    var addDescription = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var address1 = ASPxClientControl.GetControlCollection().GetByName("Address1");
    var address2 = ASPxClientControl.GetControlCollection().GetByName("Address2");
    var address3 = ASPxClientControl.GetControlCollection().GetByName("Address3");
    var city = ASPxClientControl.GetControlCollection().GetByName("City");
    var postCode = ASPxClientControl.GetControlCollection().GetByName("PostCode");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var nomCode1 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode1");
    var nomCode2 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode2");
    var nomCode3 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode3");
    var nomCode4 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode4");
    var descAddId = parseInt(addDescription.GetValue());
    var AddId = isNaN(descAddId) ? addDescription.GetValue() : descAddId;
    var ref = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var custRef = ref.GetValue(); var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox != null ? commentBox.GetValue() : "";
    nomCode = nomCode != null ? nomCode.GetValue() : "";
    nomCode1 = nomCode1 != null ? nomCode1.GetValue() : "";
    nomCode2 = nomCode2 != null ? nomCode2.GetValue() : "";
    nomCode4 = nomCode4 != null ? nomCode4.GetValue() : "";
    nomCode3 = nomCode3 != null ? nomCode3.GetValue() : "";

    $.ajax({
        url: "/Basket/FillAllAddresswidCustRef/",
        type: "POST",
        data: { 'descAddId': AddId, 'custRef': custRef, 'adddesc': AddId, 'comment': comment, 'nomCode': nomCode, 'nomCode1': nomCode1, 'nomCode2': nomCode2, 'nomCode3': nomCode3, 'nomCode4': nomCode4 },
        success: function (resp) {
            address1.SetValue(resp.BusAdd.Address1);
            address2.SetValue(resp.BusAdd.Address2);
            address3.SetValue(resp.BusAdd.Address3);
            city.SetValue(resp.BusAdd.City);
            postCode.SetValue(resp.BusAdd.PostCode);
            ref.SetValue(resp.custRef);
            commentBox.SetValue(resp.CommentExternal);
            nomCode.SetValue(resp.nomCode);
            nomCode1.SetValue(resp.nomCode);
            nomCode2.SetValue(resp.nomCode);
            nomCode3.SetValue(resp.nomCode);
            nomCode4.SetValue(resp.nomCode);
        }
    });
}

function AcceptOrder(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var addDescription = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var addDesc = addDescription != null ? addDescription.GetValue() : "";
    var ref = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var custRef = ref.GetValue(); var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox != null ? commentBox.GetValue() : "";

    //$.ajax({
    //    url: "Basket/GetCarriageStatus",
    //    type: "POST",
    //    success: function (result) {
    //        if (result) {
    if (addDesc != null && addDesc != "") {
        $.ajax({
            url: "/Basket/AcceptOrder/",
            type: "POST",
            data: { 'addDesc': addDesc },
            success: function (resp) {
                if (resp.type != "" && resp.type != null) {
                    alert("Please fill  customer reference")
                }
                else {
                    var message = "";
                    for (var k = 0; k < resp.results.length; k++) {
                        message = message + "Your uniform order has been successfully placed,order reference:" + resp.results[k].OrderNo + " (" + resp.results[k].EmployeeId + ")." + resp.results[k].OrderConfirmation + ". \n";
                    }
                    alert(message);
                    loadPopup.Hide()
                    window.location = "/Employee/Index/";
                }
            }
        });
    }
    else {
        alert("Please fill address and customer reference");
        loadPopup.Hide();
    }
    //        }
    //        else {
    //            alert("Please select a carriage");
    //        }
    //    }
    //});
}

function SettbxValue(s, e) {
    var cmbBox = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var carrTextbox = document.getElementById("CarriageValueBox");
    var data = cmbBox.GetValue().split("|");
    carrTextbox.innerHTML = data[1];

}

function saveCmt(s, e) {
    var addDescription = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var descAddId = parseInt(addDescription.GetValue());
    var AddId = isNaN(descAddId) ? addDescription.GetValue() : descAddId;
    var ref = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var custRef = ref.GetValue(); var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox != null ? commentBox.GetValue() : "";
    $.ajax({
        url: "/Basket/SaveRefnAddress/",
        type: "POST",
        data: { 'descAddId': AddId, 'custRef': custRef, 'adddesc': AddId, 'comment': comment }
    });
}

function GetNavigation(data) {
    var address = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var addressId = address.GetValue();
    var custref = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var custRefVal = custref.GetValue();
    var carrVal = ASPxClientControl.GetControlCollection().GetByName("CarriageCmbbox");
    var carr = carrVal == null ? "" : carrVal.GetValue();
    var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var nomCode1 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode1");
    var nomCode2 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode2");
    var nomCode3 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode3");
    var nomCode4 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode4");
    comment = commentBox != null ? commentBox.GetValue() : "";
    nomCode = nomCode != null ? nomCode.GetValue() : "";
    nomCode1 = nomCode1 != null ? nomCode1.GetValue() : "";
    nomCode2 = nomCode2 != null ? nomCode2.GetValue() : "";
    nomCode4 = nomCode4 != null ? nomCode4.GetValue() : "";
    nomCode3 = nomCode3 != null ? nomCode3.GetValue() : "";
    var custReflbl = "";
    if (addressId != null && addressId != undefined && addressId != "") {
        if (data != null && data != undefined) {
            $.ajax({
                url: "/Basket/GetNavigationUrl/",
                type: "POST",
                data: { 'data': data, 'addId': addressId, 'cusrRef': custRefVal, 'carr': carr, 'comment': comment, 'nomCode': nomCode, 'nomCode1': nomCode1, 'nomCode2': nomCode2, 'nomCode3': nomCode3, 'nomCode4': nomCode4 },
                success: function (resp) {
                    if (resp != "") {
                        window.location = resp;
                    }
                    else {
                        alert("Please fill Customer/PO reference");
                    }
                },
                error: function (resp) {
                    alert("Please fill Customer/PO reference");
                }
            });

        }

    }
    else {
        alert("Please fill Address & Customer/PO reference");
    }

}

function FillAllCurrentHeaderData(s, e) {
    var addDescription = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var address1 = ASPxClientControl.GetControlCollection().GetByName("Address1");
    var address2 = ASPxClientControl.GetControlCollection().GetByName("Address2");
    var address3 = ASPxClientControl.GetControlCollection().GetByName("Address3");
    var city = ASPxClientControl.GetControlCollection().GetByName("City");
    var postCode = ASPxClientControl.GetControlCollection().GetByName("PostCode");

    var custRef = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var nomCode1 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode1");
    var nomCode2 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode2");
    var nomCode3 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode3");
    var nomCode4 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode4");
    var grid = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var key = grid.GetRowKey(e.visibleIndex);
    $.ajax({
        url: "/Basket/FillHeaderDetails/",
        type: "POST",
        data: { 'key': key },
        success: function (resp) {
            if (resp != null) {
                addDescription.SetValue(resp.DelDesc);
                address1.SetValue(resp.DelAddress1);
                address2.SetValue(resp.DelAddress2);
                address3.SetValue(resp.DelAddress3);
                city.SetValue(resp.DelCity);
                postCode.SetValue(resp.DelPostCode);
                custRef.SetValue(resp.CustRef);
                commentBox.SetValue(resp.CommentExternal);
                nomCode.SetValue(resp.nomCode);
                nomCode1.SetValue(resp.nomCode);
                nomCode2.SetValue(resp.nomCode);
                nomCode3.SetValue(resp.nomCode);
                nomCode4.SetValue(resp.nomCode);
            }
        }
    });
}

function CartDetailEdit(s, e) {
    s.StartEditRow(e.visibleIndex);
    $.ajax({
        url: "/Basket/CartviewDetailGridViewGridViewPartial/",
        type: "POST",
        data: { 'key': e.visibleIndex },
        success: function (resp) {

        }
    });
}

function GetDetailsBasedonGrid(empId, busId) {
    var selected = document.getElementById(empId);
    var idaa = "col+" + empId;
    var deldiv = "delete+" + empId;
    var sel = document.getElementById(deldiv);
    sel.innerHTML = "<span style='color:red;' title=\"Click to remove this employee\" onclick=\"RemoveSelecetedEmp('" + empId + "','" + busId + "')\" class=\"glyphicon glyphicon-remove\"></span>";
    var selected1 = document.getElementById(idaa);
    selected1.innerHTML = "<span class=\"glyphicon glyphicon-chevron-right\"></span>";
    //selected1.style.backgroundColor = "#009885";
    selected1.style.color = "#009885";
    //selected.style.backgroundColor = "";
    selected.style.color = "#009885";
    var active = document.getElementsByClassName("ActiveRes");
    if (active.length > 0) {
        if (active[0].id != empId) {
            var deldiv = "delete+" + active[0].id;
            var sel = document.getElementById(deldiv);
            sel.innerHTML = "";
            var deselected = document.getElementById(active[0].id);
            deselected.style.backgroundColor = "white";
            deselected.style.color = "black";
            var idaa1 = "col+" + active[0].id;
            var deselected1 = document.getElementById(idaa1);
            deselected1.innerHTML = "";
            document.getElementById(active[0].id).classList.remove("ActiveRes");
        }
    }
    document.getElementById(empId).classList.add("ActiveRes");
    var addDescription = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var address1 = ASPxClientControl.GetControlCollection().GetByName("Address1");
    var address2 = ASPxClientControl.GetControlCollection().GetByName("Address2");
    var address3 = ASPxClientControl.GetControlCollection().GetByName("Address3");
    var city = ASPxClientControl.GetControlCollection().GetByName("City");
    var postCode = ASPxClientControl.GetControlCollection().GetByName("PostCode");
    var txtTotGoods = ASPxClientControl.GetControlCollection().GetByName("txtTotGoods");
    var txtCarrierCharges = ASPxClientControl.GetControlCollection().GetByName("txtCarrierCharges");
    var txtOrdTotal = ASPxClientControl.GetControlCollection().GetByName("txtOrdTotal");
    var txtVAT = document.getElementById("vatspan");
    var txtVAT1 = ASPxClientControl.GetControlCollection().GetByName("txtVAT");
    var txtGrndTot = ASPxClientControl.GetControlCollection().GetByName("txtGrndTot");

    var custRef = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var nomCode1 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode1");
    var nomCode2 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode2");
    var nomCode3 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode3");
    var nomCode4 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode4");
    var grid = ASPxClientControl.GetControlCollection().GetByName("CartView");
    var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox != null ? commentBox.GetValue() : "";
    grid.PerformCallback({ empid: empId });
    $.ajax({
        url: "/Basket/CartDetailEdit/",
        type: "POST",
        data: { 'empId': empId },
        success: function (resp) {
            addDescription.SetValue(resp.BusAdd.AddressDescription);
            address1.SetValue(resp.BusAdd.Address1);
            address2.SetValue(resp.BusAdd.Address2);
            address3.SetValue(resp.BusAdd.Address3);
            city.SetValue(resp.BusAdd.City);
            postCode.SetValue(resp.BusAdd.PostCode);
            custRef.SetValue(resp.custRef);
            commentBox.SetValue(resp.CommentExternal);
            txtTotGoods.SetValue(resp.ordeTotal);
            txtCarrierCharges.SetValue(resp.carriage);
            txtOrdTotal.SetValue(resp.Total);
            txtVAT.innerHTML = resp.VatPercent;
            txtVAT1.SetValue(resp.totalVat);
            txtGrndTot.SetValue(resp.GrossTotal);
            nomCode.SetValue(resp.nomCode);
            nomCode1.SetValue(resp.nomCode1);
            nomCode2.SetValue(resp.nomCode2);
            nomCode3.SetValue(resp.nomCode3);
            nomCode4.SetValue(resp.nomCode4);

        }
    });
}

function RemoveSelecetedEmp(empId, busId) {
    if (confirm("Are you sure you want to delete " + empId + "?")) {
        $.ajax({
            url: "/Basket/CartViewDelete/",
            type: "POST",
            data: { 'empId': empId },
            success: function (resp) {
                if (resp != null) {
                    alert("Successfully deleted")
                    if (resp.includes("HEADERVALUENOTZERO")) {
                        window.location.reload();
                    }
                    else {
                        window.location = "/Employee/Index?BusinessId=" + busId;
                    }

                }
            }
        });

    }
}

function NextEmployee() {
    var address = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var addressId = address.GetValue();
    var custref = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var custRefVal = custref.GetValue();
    var carrVal = ASPxClientControl.GetControlCollection().GetByName("CarriageCmbbox");
    var carr = carrVal == null ? "" : carrVal.GetValue();
    var custReflbl = "";
    var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox != null ? commentBox.GetValue() : "";
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var nomCode1 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode1");
    var nomCode2 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode2");
    var nomCode3 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode3");
    var nomCode4 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode4");
    nomCode = nomCode != null ? nomCode.GetValue() : "";
    nomCode1 = nomCode1 != null ? nomCode1.GetValue() : "";
    nomCode2 = nomCode2 != null ? nomCode2.GetValue() : "";
    nomCode4 = nomCode4 != null ? nomCode4.GetValue() : "";
    nomCode3 = nomCode3 != null ? nomCode3.GetValue() : "";
    if (addressId != null && addressId != undefined && addressId != "") {

        $.ajax({
            url: "/Basket/GetNavigationUrl/",
            type: "POST",
            data: { 'data': '>', 'addId': addressId, 'cusrRef': custRefVal, 'carr': carr, 'comment': comment, 'nomCode': nomCode, 'nomCode1': nomCode1, 'nomCode2': nomCode2, 'nomCode3': nomCode3, 'nomCode4': nomCode4 },
            success: function (resp) {
                if (resp != "") {
                    window.location = resp;
                }
                else {
                    alert("Please fill Customer/PO reference");
                }
            },
            error: function (resp) {
                alert("Please fill Customer/PO reference");
            }
        });
    }
    else {
        alert("Please fill Address & Customer/PO reference");
    }

}

function ContinueShop() {
    var address = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var addressId = address.GetValue();
    var custref = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var custRefVal = custref.GetValue();
    var carrVal = ASPxClientControl.GetControlCollection().GetByName("CarriageCmbbox");
    var carr = carrVal == null ? "" : carrVal.GetValue();
    var custReflbl = "";
    var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var nomCode1 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode1");
    var nomCode2 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode2");
    var nomCode3 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode3");
    var nomCode4 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode4");
    nomCode = nomCode != null ? nomCode.GetValue() : "";
    nomCode1 = nomCode1 != null ? nomCode1.GetValue() : "";
    nomCode2 = nomCode2 != null ? nomCode2.GetValue() : "";
    nomCode4 = nomCode4 != null ? nomCode4.GetValue() : "";
    nomCode3 = nomCode3 != null ? nomCode3.GetValue() : "";
    comment = commentBox != null ? commentBox.GetValue() : "";
    if (addressId != null && addressId != undefined && addressId != "") {

        $.ajax({
            url: "/Basket/GetNavigationUrl/",
            type: "POST",
            data: { 'data': '<', 'addId': addressId, 'cusrRef': custRefVal, 'carr': carr, 'comment': comment, 'nomCode': nomCode, 'nomCode1': nomCode1, 'nomCode2': nomCode2, 'nomCode3': nomCode3, 'nomCode4': nomCode4 },
            success: function (resp) {
                if (resp != "") {
                    window.location = resp;
                }
                else {
                    alert("Please fill Customer/PO reference");
                }
            },
            error: function (resp) {
                alert("Please fill Customer/PO reference");
            }
        });
    }
    else {
        alert("Please fill Address & Customer/PO reference");
    }

}

function UpdateCurrentEmp() {
    var address = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var addressId = address.GetValue();
    var custref = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var custRefVal = custref.GetValue();
    var carrVal = ASPxClientControl.GetControlCollection().GetByName("CarriageCmbbox");
    var carr = carrVal == null ? "" : carrVal.GetValue();
    var custReflbl = "";
    var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox != null ? commentBox.GetValue() : "";
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var nomCode1 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode1");
    var nomCode2 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode2");
    var nomCode3 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode3");
    var nomCode4 = ASPxClientControl.GetControlCollection().GetByName("txtNomCode4");
    nomCode = nomCode != null ? nomCode.GetValue() : "";
    nomCode1 = nomCode1 != null ? nomCode1.GetValue() : "";
    nomCode2 = nomCode2 != null ? nomCode2.GetValue() : "";
    nomCode4 = nomCode4 != null ? nomCode4.GetValue() : "";
    nomCode3 = nomCode3 != null ? nomCode3.GetValue() : "";
    comment = commentBox != null ? commentBox.GetValue() : "";
    if (addressId != null && addressId != undefined && addressId != "") {

        $.ajax({
            url: "/Basket/GetNavigationUrl/",
            type: "POST",
            data: { 'data': '>', 'addId': addressId, 'cusrRef': custRefVal, 'carr': carr, 'comment': comment, 'nomCode': nomCode, 'nomCode1': nomCode1, 'nomCode2': nomCode2, 'nomCode3': nomCode3, 'nomCode4': nomCode4 },
            success: function (resp) {
                if (resp != "") {
                    alert("Successfully updated");
                    MVCxClientUtils.FinalizeCallback();
                }
                else {
                    alert("Please fill Customer/PO reference");
                }
            },
            error: function (resp) {
                alert("Please fill Customer/PO reference");
            }
        });


    }
    else {
        alert("Please fill Address & Customer/PO reference");
    }

}

function OnEndCallback(s, e) {
    var txtTotGoods = ASPxClientControl.GetControlCollection().GetByName("txtTotGoods");
    var txtCarrierCharges = ASPxClientControl.GetControlCollection().GetByName("txtCarrierCharges");
    var txtOrdTotal = ASPxClientControl.GetControlCollection().GetByName("txtOrdTotal");
    var txtVAT = document.getElementById("vatspan");
    var txtVAT1 = ASPxClientControl.GetControlCollection().GetByName("txtVAT");
    var txtGrndTot = ASPxClientControl.GetControlCollection().GetByName("txtGrndTot");
    if (updateEdit != "" && updateEdit != undefined && updateEdit != null) {
        $.ajax({
            url: "/Basket/GetPrice/",
            type: "GET",
            success: function (resp) {
                txtTotGoods.SetValue(resp.ordeTotal);
                txtCarrierCharges.SetValue(resp.carriage);
                txtOrdTotal.SetValue(resp.Total);
                txtVAT.innerHTML = resp.VatPercent;
                txtVAT1.SetValue(resp.totalVat);
                txtGrndTot.SetValue(resp.GrossTotal);
            },
            error: function () {

            }
        });
        updateEdit = "";
    }
}

function OnBeginCallback(s, e) {
    if (e.command == "UPDATEEDIT") {
        updateEdit = "UPDATEEDIT";
    }
}

function GetBulkPrice(size, style, orgStyle) {
    var styleId_Val = style.includes(",") ? GetStyleIdSwatch(style, orgStyle) : style;
    var name = "BulkSizeBox_" + size + "_" + style;
    //var socNams = $("." + name);
    var docName = document.getElementById(name);
    var qty = docName != null && docName != undefined && docName.value != "" ? docName.value : "0";
    //if (qty != "") {
    //    if (isNaN(qty) != true) {
    //        $.ajax({
    //            url: "/Home/GetBulkPrice/",
    //            data: { 'qty': qty, 'style': styleId_Val, 'size': size },
    //            type: "post",
    //            success: function (response) {
    //                if (isNaN(response) == false) {
    //                    var priceId = "LbPrice_" + style + "_" + size;
    //                    var price = document.getElementById(priceId);
    //                    price.innerHTML = "";
    //                    price.innerHTML = response;
    //                }
    //            },
    //            error: function () {

    //            }
    //        });
    //    }
    //}
}

function SetManPack(s, e) {
    var chk = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var value = chk.GetValue();
    if (value != null) {
        $.ajax({
            url: "/Settings/SetManpack/",
            type: "Post",
            data: { 'value': value },
            success: function (res) {

            }
        });
    }
}

function OrderTypeChange(s, e) {
    var dat = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var setOrderType = dat.GetValue();
    if (setOrderType) {
        $.ajax({
            url: "/Settings/SetOrderType/",
            type: "POST",
            data: { 'setOrderType': s.name },
            success: function () {

            }
        });
    }
}

function addToCartBulkOrder1(s, e) {
    var SizePriceArray = [];
    var QtySizePriceArr1 = [];
    var QtySizePriceArr;
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var stylearr = s.name.split('_');
    var bulkSizeName = "BulkOrder1_" + stylearr[1];
    var bulkSizes = document.getElementsByClassName(bulkSizeName);
    var descStyle; var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var colorValue;
    var sizeValue;
    for (var i = 0; i < bulkSizes.length; i++) {
        if (bulkSizes[i].innerText != "") {
            var ssss = bulkSizes[i].innerText.replace(/\n/ig, '');
            var index = 0;
            if (ssss.includes('£')) {
                for (var j = 0; j < ssss.length; j++) {
                    if (ssss[j] == '£') {
                        SizePriceArray.push({ 'Size': ssss.substring(0, j), 'Price': ssss.substring(j + 1, ssss.length), 'Id': stylearr[1] + "_" + ssss.substring(0, j) });
                    }
                }
            }
            else {
                SizePriceArray.push({ 'Size': ssss, 'Price': 0, 'Id': stylearr[1] + "_" + ssss });
            }

        }
    }
    var contnt = "";
    for (var k = 0; k < SizePriceArray.length; k++) {
        if (SizePriceArray[k].Price == "") {
            var priceId = document.getElementById("BulkOrder1_Price" + stylearr[1]);
            if (priceId != null) {
                var price = priceId.value;
                if (price == "") {
                    return alert("Please enter price for  size " + SizePriceArray[k].Size);
                }
                else {
                    SizePriceArray[k].Price = price;
                }
            }
        }
    }
    for (var j = 0; j < SizePriceArray.length; j++) {
        var doc = document.getElementById(SizePriceArray[j].Id);
        var ReqId = 'ReqData_' + SizePriceArray[j].Id;
        var Req = document.getElementById(ReqId);
        var reqVal = Req == null ? "" : Req.value == "" ? "noVal" : Req.value;

        if (doc.value != "") {
            if (doc.value > 0) {
                QtySizePriceArr1.push({ 'Size': SizePriceArray[j].Size, 'Price': SizePriceArray[j].Price, 'Qty': doc.value, 'ReqData': reqVal })
            }
        }
    }
    for (var j = 0; j < QtySizePriceArr1.length; j++) {
        if (QtySizePriceArr1[j].ReqData == "noVal") {
            contnt = contnt + "Please enter required data for the size" + QtySizePriceArr1[j].Size + "\n";
        }
    }

    if (stylearr[1].includes(',')) {
        var name = 'Swatch_Style_FieldSet_' + stylearr[1];
        var fieldSet = document.getElementsByName(name);
        var selStyle;
        for (var i = 0; i < fieldSet[0].elements.length; i++) {
            if (fieldSet[0].elements[i].checked) {
                selStyle = fieldSet[0].elements[i].value;
            }
        }
        sStyle = selStyle;
        descStyle = stylearr[1].split(',');
    }
    else {
        sStyle = stylearr[1];
    }
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var description = "";
    var descriptionDiv = document.getElementById("LbDescription" + desc);
    description = descriptionDiv.innerHTML;

    var colorSwatchName = "swatch_Color_" + stylearr[1];
    var colorSwatch = document.getElementsByName(colorSwatchName);
    var sizeSwatchName = "swatch_Size_" + stylearr[1];
    var sizeSwatch = document.getElementsByName(sizeSwatchName);
    var reasonName = "CmbReason_" + stylearr[1];
    var reasonControl = document.getElementsByName(reasonName);
    var reason;
    QtySizePriceArr = JSON.stringify(QtySizePriceArr1);

    if (reasonControl.length > 0) {
        reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;
    }

    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    color = colorValue != undefined && colorValue != "" ? colorValue : "";
    if (color != "" && color != null && QtySizePriceArr1.length > 0 && contnt == "" && description != "" && description != null) {
        $.ajax({
            type: "POST",
            url: "/Home/AddToCart/",
            data: { 'description': description, 'color': color, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'QtySizePriceArr': QtySizePriceArr },
            success: function (response) {
                if (response != "") {
                    $("#CartwidCount").html("");
                    $("#CartwidCount").html(response);
                    loadPopup.Hide();
                    myFunction("Added to cart..!");
                    //myFunction("Added to cart..!");  ;
                }
                else {
                    loadPopup.Hide();
                    myFunction("Try again..!");
                    //alert("Try again!");
                }
            },
            failure: function (response) {

            }
        });
    }
    else {
        if (contnt != "") {
            alert(contnt);
            loadPopup.Hide();
        }
        else {
            alert("Please select add a quantity");
            loadPopup.Hide();
        }
    }

}

function GetPriceValue(id) {
    var s = document.getElementById(id).value;
    $("#" + id).val(s);
}

function addTocartTemplateBulkOrder1(s, e) {
    var SizePriceArray = [];
    var QtySizePriceArr1 = [];
    var QtySizePriceArr;
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var stylearr = s.name.split('_');
    var bulkSizeName = "BulkOrder1_template_" + stylearr[1];
    var bulkSizes = document.getElementsByClassName(bulkSizeName);
    var descStyle; var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var colorValue;
    var sizeValue;
    for (var i = 0; i < bulkSizes.length; i++) {
        if (bulkSizes[i].innerText != "") {
            var ssss = bulkSizes[i].innerText.replace(/\n/ig, '');
            var index = 0;
            if (ssss.includes('£')) {
                for (var j = 0; j < ssss.length; j++) {
                    if (ssss[j] == '£') {
                        SizePriceArray.push({ 'Size': ssss.substring(0, j), 'Price': ssss.substring(j + 1, ssss.length), 'Id': stylearr[1] + "_" + ssss.substring(0, j) });
                    }
                }
            }
            else {
                SizePriceArray.push({ 'Size': ssss, 'Price': 0, 'Id': stylearr[1] + "_" + ssss });
            }

        }
    }
    var contnt = "";
    for (var k = 0; k < SizePriceArray.length; k++) {
        if (SizePriceArray[k].Price == "") {
            var priceId = document.getElementById("BulkOrder1_template_Price" + stylearr[1]);
            if (priceId != null) {
                var price = priceId.value;
                if (price == "") {
                    return alert("Please enter price for  size " + SizePriceArray[k].Size);
                }
                else {
                    SizePriceArray[k].Price = price;
                }
            }
        }
    }
    for (var j = 0; j < SizePriceArray.length; j++) {
        var doc = document.getElementById(SizePriceArray[j].Id);
        var ReqId = 'ReqData_' + SizePriceArray[j].Id;
        var Req = document.getElementById(ReqId);
        var reqVal = Req == null ? "" : Req.value == "" ? "noVal" : Req.value;

        if (doc.value != "") {
            if (doc.value > 0) {
                QtySizePriceArr1.push({ 'Size': SizePriceArray[j].Size, 'Price': SizePriceArray[j].Price, 'Qty': doc.value, 'ReqData': reqVal })
            }
        }
    }
    for (var j = 0; j < QtySizePriceArr1.length; j++) {
        if (QtySizePriceArr1[j].ReqData == "noVal") {
            contnt = contnt + "Please enter required data for the size" + QtySizePriceArr1[j].Size + "\n";
        }
    }

    if (stylearr[1].includes(',')) {
        var name = 'Swatch_Style_FieldSet_' + stylearr[1];
        var fieldSet = document.getElementsByName(name);
        var selStyle;
        for (var i = 0; i < fieldSet[0].elements.length; i++) {
            if (fieldSet[0].elements[i].checked) {
                selStyle = fieldSet[0].elements[i].value;
            }
        }
        sStyle = selStyle;
        descStyle = stylearr[1].split(',');
    }
    else {
        sStyle = stylearr[1];
    }
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var description = "";
    var descriptionDiv = document.getElementById("LbDescription" + desc);
    description = descriptionDiv.innerHTML;

    var colorSwatchName = "Swatch_ColorTemplate_" + stylearr[1];
    var colorSwatch = document.getElementsByName(colorSwatchName);
    var sizeSwatchName = "swatchTemplate_Size_" + stylearr[1];
    var sizeSwatch = document.getElementsByName(sizeSwatchName);
    var reasonName = "CmbReason_" + stylearr[1];
    var reasonControl = document.getElementsByName(reasonName);
    var reason;
    QtySizePriceArr = JSON.stringify(QtySizePriceArr1);

    if (reasonControl.length > 0) {
        reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;
    }

    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    color = colorValue != undefined && colorValue != "" ? colorValue : "";
    if (color != "" && color != null && QtySizePriceArr1.length > 0 && contnt == "" && description != "" && description != null) {
        $.ajax({
            type: "POST",
            url: "/Home/AddToCart/",
            data: { 'description': description, 'color': color, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'QtySizePriceArr': QtySizePriceArr },
            success: function (response) {
                if (response != "") {
                    $("#CartwidCount").html("");
                    $("#CartwidCount").html(response);
                    loadPopup.Hide();
                    myFunction("Added to cart..!");
                    //myFunction("Added to cart..!");  ;
                }
                else {
                    loadPopup.Hide();
                    myFunction("Try again..!");
                    //alert("Try again!");
                }
            },
            failure: function (response) {

            }
        });
    }
    else {
        if (contnt != "") {
            alert(contnt);
        }
        else {
            if (color == "" | color == null) {
                loadPopup.Hide();
                alert("Please select a color");
            }
            else if (QtySizePriceArr1.length == 0) {
                loadPopup.Hide();
                alert("Please select add a quantity");
            }
        }
    }
}


function addToCartDemandBulkOrder1(s, e) {
    var SizePriceArray = [];
    var QtySizePriceArr1 = [];
    var QtySizePriceArr;
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var stylearr = s.name.split('_');
    var bulkSizeName = "BulkOrder1_Demand_" + stylearr[1];
    var bulkSizes = document.getElementsByClassName(bulkSizeName);
    var descStyle; var price = "";
    var size = "";
    var color = "";
    var qty = "";
    var sStyle = "";
    var descStyle;
    var colorValue;
    var sizeValue;
    var colorSwatchName = "swatch_DemandColor_" + stylearr[1];
    var colorSwatch = document.getElementsByName(colorSwatchName);
    var sizeSwatchName = "swatch_DemandSize_" + stylearr[1];
    var sizeSwatch = document.getElementsByName(sizeSwatchName);
    var reasonName = "CmbDemandReason_" + stylearr[1];
    var reasonControl = document.getElementsByName(reasonName);
    var reason;
    var description;
    for (var i = 0; i < bulkSizes.length; i++) {
        if (bulkSizes[i].innerText != "") {
            var ssss = bulkSizes[i].innerText.replace(/\n/ig, '');
            var index = 0;
            if (ssss.includes('£')) {
                for (var j = 0; j < ssss.length; j++) {
                    if (ssss[j] == '£') {
                        SizePriceArray.push({ 'Size': ssss.substring(0, j), 'Price': ssss.substring(j + 1, ssss.length), 'Id': stylearr[1] + "_demand_" + ssss.substring(0, j) });
                    }
                }
            }
            else {
                SizePriceArray.push({ 'Size': ssss, 'Price': 0, 'Id': stylearr[1] + "_demand_" + ssss });
            }

        }
    }
    var contnt = "";
    for (var k = 0; k < SizePriceArray.length; k++) {
        if (SizePriceArray[k].Price == "") {
            var priceId = document.getElementById("BulkOrder1_price_Demand_" + stylearr[1]);
            if (priceId != null) {
                var price = priceId.value;

                if (price == "") {
                    return alert("Please enter price for  size " + SizePriceArray[k].Size);
                }
                else {
                    SizePriceArray[k].Price = price;
                }
            }
        }
    }
    for (var j = 0; j < SizePriceArray.length; j++) {
        var doc = document.getElementById(SizePriceArray[j].Id);
        var ReqId = 'ReqData_demand_' + SizePriceArray[j].Id;
        var Req = document.getElementById(ReqId);
        var reqVal = Req == null ? "" : Req.value == "" ? "noVal" : Req.value;

        if (doc.value != "") {
            if (doc.value > 0) {
                QtySizePriceArr1.push({ 'Size': SizePriceArray[j].Size, 'Price': SizePriceArray[j].Price, 'Qty': doc.value, 'ReqData': reqVal })
            }
        }
    }
    for (var j = 0; j < QtySizePriceArr1.length; j++) {
        if (QtySizePriceArr1[j].ReqData == "noVal") {
            contnt = contnt + "Please enter required data for the size" + QtySizePriceArr1[j].Size + "\n";
        }
    }

    if (reasonControl.length > 0) {
        reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;
    }
    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    color = colorValue != undefined | colorValue != "" ? colorValue : "";

    if (stylearr[1].includes(',')) {
        var name = 'Swatch_DemandStyle_FieldSet_' + stylearr[1];
        var fieldSet = document.getElementsByName(name);
        var selStyle;
        for (var i = 0; i < fieldSet[0].elements.length; i++) {
            if (fieldSet[0].elements[i].checked) {
                selStyle = fieldSet[0].elements[i].value;
            }
        }
        sStyle = selStyle;
        descStyle = stylearr[1].split(',');
    }
    else {
        sStyle = stylearr[1];
    }
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    QtySizePriceArr = JSON.stringify(QtySizePriceArr1);

    if (reasonControl.length > 0) {
        reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;
    }

    if (colorSwatch.length > 1) {
        for (var i = 0; i < colorSwatch.length; i++) {
            if (colorSwatch[i].checked) {
                colorValue = colorSwatch[i].offsetParent.innerText;
            }
        }
    }
    else {
        if (colorSwatch[0].checked) {
            colorValue = colorSwatch[0].offsetParent.innerText;
        }
    }
    description = document.getElementById("LbdemandDescription" + desc).innerHTML;
    color = colorValue != undefined && colorValue != "" ? colorValue : "";
    if (color != "" && color != null && QtySizePriceArr1.length > 0 && contnt == "" && description != "" && description != null) {
        $.ajax({
            type: "POST",
            url: "/Home/AddToCart/",
            data: { 'description': description, 'color': color, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'QtySizePriceArr': QtySizePriceArr },
            success: function (response) {
                if (response != "") {
                    $("#CartwidCount").html("");
                    $("#CartwidCount").html(response);
                    loadPopup.Hide();
                    myFunction("Added to cart..!");
                    //myFunction("Added to cart..!");  ;
                }
                else {
                    loadPopup.Hide();
                    myFunction("Try again..!");
                    //alert("Try again!");
                }
            },
            failure: function (response) {

            }
        });
    }
    else {
        if (contnt != "") {
            alert(contnt);
            loadPopup.Hide();
        }
        else {
            alert("Please select add a quantity");
            loadPopup.Hide();
        }
    }
}

function GetQtyData() {

}

function GetFreeData() {
    alert("freedata");
}

function GetSelectedOrder() {
    var orderTypeCtrl = ASPxClientControl.GetControlCollection().GetByName("OrderType");
    var orderType = orderTypeCtrl.GetValue();
    $.ajax({
        url: "/Employee/ChangeOrderType/",
        data: { 'orderType': orderType },
        type: "Post",
        success: function (resp) {
            if (resp != "") {
                window.location = "/Employee/Index?BusinessID=" + resp;
            }
        },
        failure: function (resp) {

        }
    });
}

function SetValue111(ucode, type) {
    var url1 = "";
    var ucodeDivs = document.getElementsByClassName("ucodeCard");
    for (var i = 0; i < ucodeDivs.length; i++) {
        if (ucodeDivs[i].id.toLowerCase() == ucode.toLowerCase()) {
            ucodeDivs[i].className = "MyThumbnail1 ucodeCard";
        }
        else {
            ucodeDivs[i].className = "MyThumbnail ucodeCard";
        }
    }
    if (type.toLowerCase() == "template") {
        $.ajax({

            url: "/Employee/GotoCardTemplate/",
            type: "post",
            data: { 'EmployeeId': "", 'EmpName': "", 'Template': ucode },
            success: function (resp) {
                if (resp != "") {
                    window.location = resp;
                }
            },
            failure: function (resp) {

            }
        });
    }
    else {
        $.ajax({
            url: "/Employee/GotoCard/",
            type: "post",
            data: { 'EmployeeId': "", 'EmpName': "", 'Ucodes': ucode },
            success: function (resp) {
                if (resp != "") {
                    window.location = resp;
                }
            },
            failure: function (resp) {

            }
        });

    }

}

function IsCallBack(s, e) {
    e.customArgs["IsCallBack"] = true;
}