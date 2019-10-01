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
            url: '/Home/GetPrice/',
            data: { 'StyleID': styleId_Val, 'SizeId': size },
            success: function (response) {
                ;
                if (!response.includes("Login")) { 
                    var priceId = "LbPrice" + style;
                    var price = document.getElementById(priceId);
                    price.innerHTML = "";
                    price.innerHTML = response;
                }
                else
                {
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
                else
                {
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

    if (size != "" && styleId_Val != "") {

        $.ajax({
            type: "POST",
            url: '/Home/GetPrice/',
            data: { 'StyleID': styleId_Val, 'SizeId': size },
            success: function (response) {
                ;
                if (!response.includes("Login")) {
                    var priceId = "DimviewPrice" + style;
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
    size = sizeValue != undefined | sizeValue != "" ? sizeValue : "";
    color = colorValue != undefined | colorValue != "" ? colorValue : "";

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
    description = document.getElementById("LbDescription" + desc).innerHTML;
    price = document.getElementById("LbPrice" + stylearr[1]).innerHTML;
    qty = Spin[0].value;
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
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3] },
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
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3] },
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
        alert("Please select all the fields in the cards!");
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
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle },
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
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle },
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
        alert("Please select all the fields in the cards!");
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
    description = document.getElementById("LbdemandDescription" + desc).innerHTML;
    price = document.getElementById("DimviewPrice" + stylearr[1]).innerHTML;
    qty = Spin[0].value;
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
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3] },
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
                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3] },
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
        alert("Please select all the fields in the cards!");
    }
}

function GetDrpResultModelSwatch(stle, selStyle, orgStyle) {
    var style_nam = stle;
    //var stylearr = style_nam.split('_');
    //var selStyle = s.GetSelectedItem(style_nam).value;
    var colorFieldsetName = "Swatch_Color_FieldSet_" + style_nam;
    var sizeFieldsetName = "Swatch_Size_FieldSet_" + style_nam;
    var colorFieldset = document.getElementsByName(colorFieldsetName);
    var sizeFieldset = document.getElementsByName(sizeFieldsetName);
    var clrContent = "";
    var sizContent = "";
    var description = document.getElementById("LbDescription" + style_nam.split(',')[0]);
    description.innerHTML = "";
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

                            description.innerHTML = response.Description;

                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    colorFieldset[0].innerHTML = "";
                                    clrContent = clrContent + "<label class='swatchLabel'><input type='radio'  onchange='GetClrImg('" + style_nam + "-" + response.ColorList[i] + "')' id='radio' name=\"swatch_Color_" + style_nam + "\" value='blue'/><span class='spanner1'  ><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    colorFieldset[0].innerHTML = "";
                                    clrContent = clrContent + "<label class='swatchLabel'><input type='radio'  onchange='GetClrImg('" + style_nam + "-" + response.ColorList[i] + "')' id='radio' name=\"swatch_Color_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    if (response.SizeList[i] == resp.Size) {
                                        sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                    else {
                                        sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                                else {
                                    sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent != "" ? clrContent : colorFieldset[0].innerHTML;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "LbPrice" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? resp.price == "" ? "" : resp.price : response.Price;

                        } else {
                            description.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" value='blue'/><span class='spanner1'onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_Color_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' height:100%;width:100%;' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_Size_" + style_nam + "\" checked=\"checked\"/><span class='spanner1'  onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "LbPrice" + style_nam;
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

                            description.innerHTML = response.Description;

                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    colorFieldset[0].innerHTML = "";
                                    clrContent = clrContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedColorSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    colorFieldset[0].innerHTML = "";
                                    clrContent = clrContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedColorSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    if (response.SizeList[i] == resp.Size) {
                                        sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                    else {
                                        sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                    }
                                }
                                else {
                                    sizContent = sizContent + "<label class='swatchLabel'><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + orgStyle + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent != "" ? clrContent : colorFieldset[0].innerHTML;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "DimviewPrice" + style_nam;
                            var price = document.getElementById(priceId);
                            price.innerHTML = "";
                            price.innerHTML = response.Price == 0 ? resp.price == "" ? "" : resp.price : response.Price;

                        } else {
                            description.innerHTML = response.Description;
                            colorFieldset[0].innerHTML = "";
                            sizeFieldset[0].innerHTML = "";
                            for (var i = 0; i < response.ColorList.length ; i++) {
                                if (response.ColorList.length > 1) {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" value='blue'/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    clrContent = clrContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandColor_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeSwatch('" + style_nam + "','" + response.ColorList[i] + "')\"><center><bold>" + response.ColorList[i] + "</bold></center></span></label>";
                                }
                            }
                            for (var i = 0; i < response.SizeList.length ; i++) {
                                if (response.SizeList.length > 1) {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                                else {
                                    sizContent = sizContent + "<label><input type='radio'  id='radio' name=\"swatch_DemandSize_" + style_nam + "\" checked=\"checked\"/><span class='spanner1' onclick=\"getSelectedSizeDemandSwatch('" + style_nam + "','" + response.SizeList[i] + "','" + stylearr[1] + "')\"><center><bold>" + response.SizeList[i] + "</bold></center></span></label>";
                                }
                            }
                            colorFieldset[0].innerHTML = clrContent;
                            sizeFieldset[0].innerHTML = sizContent;
                            var priceId = "DimviewPrice" + style_nam;
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
                            var priceId = "DimviewPrice" + style_nam;
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
                            var priceId = "DimviewPrice" + style_nam;
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
                else
                {
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
    var selectedSize = size;
    if (selectedSize != "") {

        $.ajax({
            type: "POST",
            url: "/Home/GetPrice/",
            data: { 'StyleID': style, 'SizeId': selectedSize },
            success: function (response) {
                if (!response.includes("Login")) {
                    var priceId = "LbTemplatePrice" + style;
                    var price = document.getElementById(priceId);
                    price.innerHTML = "";
                    price.innerHTML = response;
                }
                else
                {
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
    sStyle = stylearr[1];
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = "spinEdit_" + stylearr[1];
    var qty1 = document.getElementsByName(Spin);
    description = document.getElementById("LbDescription" + desc).innerHTML;
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
                    myFunction("Added to cart..!");  ;
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
        alert("Please select all the fields in the cards!");
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
                    myFunction("Added to cart..!");  ;
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
        alert("Please select all the fields in the cards!");
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
                    MVCxClientUtils.FinalizeCallback();
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
    if (s.name != "UpdateBtn_Template") {
        selUcode = ASPxClientControl.GetControlCollection().GetByName("checkComboEdit");
    }
    var strtDate = ASPxClientControl.GetControlCollection().GetByName("editStartDate");
    var endDate = ASPxClientControl.GetControlCollection().GetByName("editStartDate");
    var isAct = ASPxClientControl.GetControlCollection().GetByName("editEmpIsActive");
    var address = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    if (s.name != "UpdateBtn_Template") {
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & selUcode.lastChangedValue != null & strtDate.date != null & address.lastSuccessText != null & endDate.date != null) {
            if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & selUcode.lastChangedValue.trim() != "" & strtDate.date != "" & address.lastSuccessText.trim() != "" & endDate.date != "") {
                if (address.lastSuccessText.trim() != '') {

                    var data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': isAct.previousValue };
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EditEmployee/",
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

                else {
                    alert("Please select a valid Address");
                }
            }
        }
        else {
            alert("Please fill all details");
        }
    }
    else {
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & strtDate.date != null & address.lastSuccessText != null & endDate.date != null) {
            if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & strtDate.date != "" & address.lastSuccessText.trim() != "" & endDate.date != "") {
                if (address.lastSuccessText.trim() != '') {

                    var data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': isAct.previousValue };
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EditEmployee/",
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

                else {
                    alert("Please select a valid Address");
                }
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
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & selUcode.lastChangedValue != null & strtDate.date != null & address.lastSuccessText != null & endDate.date != null) {
            if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & selUcode.lastChangedValue.trim() != "" & strtDate.date != "" & address.lastSuccessText.trim() != "" & endDate.date != "") {
                if (address.lastSuccessText.trim() != '') {
                    var data1;
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EmployeeIdValidation/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (response) {
                            if (response == "Success") {
                                if (isAct.previousValue == false) {
                                    if (confirm("Do you want to set the employee Active")) {
                                        data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': true, 'isMapped': isMapped };
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
                                        data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': isAct.previousValue };
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
                                    data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': isAct.previousValue };
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
                else {
                    alert("Please select a valid Address");
                }
            }
        }
        else {
            alert("Please fill all details");
        }
    }
    else {
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & strtDate.date != null & address.lastSuccessText != null & endDate.date != null) {
            if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & strtDate.date != "" & address.lastSuccessText.trim() != "" & endDate.date != "") {
                if (address.lastSuccessText.trim() != '') {
                    var data1;
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EmployeeIdValidation/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (response) {
                            if (response == "Success") {
                                if (isAct.previousValue == false) {
                                    if (confirm("Do you want to set the employee Active")) {
                                        data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': true };
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
                                        data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': isAct.previousValue };
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
                                    data1 = { 'StartDate': strtDate.date.toJSON(), 'EndDate': endDate.date.toJSON(), 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address.lastSuccessText.trim(), 'isActive': isAct.previousValue };
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
                else {
                    alert("Please select a valid Address");
                }
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

//jQuery(document).ready(function () {

//});
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
    if (!isNaN(currentVal) && currentVal > 0) {
        // Decrement one
        document.getElementsByName(name)[0].value = currentVal - 1;
    } else {
        // Otherwise put a 0 there
        document.getElementsByName(name)[0].value = 0;
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
        if (!isNaN(currentVal) && currentVal > 0) {
            // Decrement one
            document.getElementsByName(fieldName)[0].value = currentVal - 1;
        } else {
            // Otherwise put a 0 there
            document.getElementsByName(fieldName)[0].value = 0;
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
    var country = ASPxClientControl.GetControlCollection().GetByName("Country");
    var custRef = ASPxClientControl.GetControlCollection().GetByName("ddlCustRef");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var descAddId = parseInt(addDescription.GetValue());
    $.ajax({
        url: "/Basket/FillAllAddress/",
        type: "POST",
        data: { 'descAddId': descAddId },
        success: function (resp) {
            address1.SetValue(resp.BusAdd.Address1);
            address2.SetValue(resp.BusAdd.Address2);
            address3.SetValue(resp.BusAdd.Address3);
            city.SetValue(resp.BusAdd.City);
            postCode.SetValue(resp.BusAdd.PostCode);
            country.SetValue(resp.BusAdd.Country);
            custRef.SetValue(resp.custRef);
            nomCode.SetValue(resp.nomCode);
        }
    });
}

function AcceptOrder() {
    $.ajax({
        url: "/Basket/AcceptOrder/",
        type: "POST",
        data: { 'addressId': 102331 },
        success: function (resp) {

        }
    });
}

function SettbxValue(s, e) {
    var cmbBox = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var carrTextbox = ASPxClientControl.GetControlCollection().GetByName("CarriageTexbox");
    var data = cmbBox.GetValue().split("|");
    carrTextbox.SetValue(data[1]);

}

function FillCustRefandDeliveryFields(s, e) {
    var addDescription = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var address1 = ASPxClientControl.GetControlCollection().GetByName("Address1");
    var address2 = ASPxClientControl.GetControlCollection().GetByName("Address2");
    var address3 = ASPxClientControl.GetControlCollection().GetByName("Address3");
    var city = ASPxClientControl.GetControlCollection().GetByName("City");
    var postCode = ASPxClientControl.GetControlCollection().GetByName("PostCode");
    var country = ASPxClientControl.GetControlCollection().GetByName("Country");
    var custRef = ASPxClientControl.GetControlCollection().GetByName("ddlCustRef");
    var nomCode = ASPxClientControl.GetControlCollection().GetByName("txtNomCode");
    var descAddId = parseInt(addDescription.GetValue());
    $.ajax({
        url: "/Basket/FillAllAddresswidCustRef/",
        type: "POST",
        data: { 'descAddId': descAddId },
        success: function (resp) {
            address1.SetValue(resp.BusAdd.Address1);
            address2.SetValue(resp.BusAdd.Address2);
            address3.SetValue(resp.BusAdd.Address3);
            city.SetValue(resp.BusAdd.City);
            postCode.SetValue(resp.BusAdd.PostCode);
            country.SetValue(resp.BusAdd.Country);
            custRef.SetValue(resp.custRef);
            nomCode.SetValue(resp.nomCode);
        }
    });
}


//$(document).ready(function () {

//    $("#FilterEmployeeId_I").autocomplete({
//            source: function (request, response) {
//                $.ajax({
//                    url: "/Employee/GetAutocompleteVal",
//                    type: "POST",
//                    dataType: "json",
//                    data: {
//                        keyword: request.term
//                    },
//                    success: function (data) {
//                        data
//                    },
//                    error: function () {
//                        alert('something went wrong !');
//                    }
//                })
//            },
//            messages: {
//                noResults: "",
//                results: ""
//            }
//        });

//});