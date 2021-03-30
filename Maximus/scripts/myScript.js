var updateEdit = "";

function getEntitlement1(style) {
    var colordrop = "ColorPop_" + "Drop_" + style;
    var colorValue = document.getElementsByName(colordrop);
    var selectedcolor = colorValue[0].defaultValue == "" & colorValue[0].value == "" ? "" : colorValue[0].defaultValue != "" ? colorValue[0].defaultValue : colorValue[0].value;
    if (style.indexOf(',') > -1) {
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
    if (style.indexOf(',') > -1) {
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
    if (style.indexOf(',') > -1) {
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
                        if (response.Result.indexOf('points') > -1) {
                            var data = response.Result.split("-////-");

                            if (response.availPts > 0) {
                                if (response.minMandatoryPts > 0) {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                                }
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                            }

                        }
                        else {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                        }

                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
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
                    if (response.Result.indexOf('points') > -1) {
                        if (response.availPts > 0) {
                            if (response.minMandatoryPts > 0) {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                            }
                        }
                        else {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                        }

                    }
                    else {
                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                    }
                }
                var data = document.getElementById("Entitlement");
                data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
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
    if (style.indexOf(',') > -1) {
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
                        if (response.Result.indexOf('points') > -1) {
                            if (response.availPts > 0) {
                                if (response.minMandatoryPts > 0) {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded.Cannot proceed.</span></div>";
                                }
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                            }
                        }
                        else {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                        }
                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
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
                    if (response.Result.indexOf('points') > -1) {
                        if (response.availPts > 0) {
                            if (response.minMandatoryPts > 0) {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                            }
                        }
                        else {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                        }
                    }
                    else {
                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                    }
                }
                var data = document.getElementById("Entitlement");
                data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
                Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                Entitlement.Show();
            },
            error: function (response) {

            }
        });
    }
}



function getSelectedSizeSwatch(style, size, orgStyle) {
    var styleId_Val = style.indexOf(",") > -1 ? GetStyleIdSwatch(style, orgStyle) : style;

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
                            if (!response.indexOf("Login") > -1) {
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
                            if (!response.indexOf("Login") > -1) {
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
    var styleId_Val = style.indexOf(",") > -1 ? GetStyleId(style) : style;

    if (size != "" && styleId_Val != "") {

        $.ajax({
            type: "POST",
            url: '/Home/GetPrice/',
            data: { 'StyleID': styleId_Val, 'SizeId': size },
            success: function (response) {
                ;
                if (!response.indexOf("Login") > -1) {
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

    var styleId_Val = style.indexOf(",") > -1 ? GetStyleIdDemandSwatch(style, orgStyle) : style;
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
                            if (!response.indexOf("Login") > -1) {
                                var priceId = "DimviewPriceinput1" + style;
                                var price = document.getElementById(priceId);
                                price.value = "";
                                price.value = response;

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
                            if (!response.indexOf("Login") > -1) {
                                var priceId = "DimviewPriceinput1" + style;
                                var price = document.getElementById(priceId);
                                price.value = "";
                                price.value = response;

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

function getEntitlementSwatch(style, orgStyl, error, size) {
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
        if (style.indexOf(',') > -1) {
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
                data: { 'StyleId': selStyle, 'ColorId': selectedcolor, 'orgStyl': orgStyl, 'size': size },
                success: function (response) {
                    if (response != "") {
                        var errorMsg = "";
                        if (error == 1) {
                            if (response.Result.indexOf('points') > -1) {
                                if (response.availPts > 0) {
                                    if (response.minMandatoryPts > 0) {
                                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                    }
                                    else {
                                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded.  Cannot proceed.</span></div>";
                                    }
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                                }
                            }
                            else if (response.isfreestk) {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed. Order quantity exceeds freestock quantity</span></div>";
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                            }
                        }
                        var data = document.getElementById("Entitlement");
                        data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
                        if (response.isfreestk) {
                            Entitlement.SetHeaderText("Freestock for "+ response.EmpId);
                        }
                        else {
                            Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                        }
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
                data: { 'StyleId': style, 'ColorId': selectedcolor, 'orgStyl': style, 'size': size },
                success: function (response) {
                    var errorMsg = "";
                    if (error == 1) {
                        if (response.Result.indexOf('points') > -1) {
                            if (response.availPts > 0) {
                                if (response.minMandatoryPts > 0) {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded.Cannot proceed.</span></div>";
                                }
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                            }
                        } else if (response.isfreestk) {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed. Order quantity exceeds freestock quantity</span></div>";
                        }
                        else {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                        }
                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
                    if (response.isfreestk) {
                        Entitlement.SetHeaderText("Freestock for "+ response.EmpId);
                    }
                    else {
                        Entitlement.SetHeaderText("Entitlement for " + response.EmpId);
                    }
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
        if (style.indexOf(',') > -1) {
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
                            if (response.Result.indexOf('points') > -1) {
                                if (response.availPts > 0) {
                                    if (response.minMandatoryPts > 0) {
                                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                    }
                                    else {
                                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                                    }
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                                }
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                            }
                        }
                        var data = document.getElementById("Entitlement");
                        data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
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
                        if (response.Result.indexOf('points') > -1) {
                            if (response.availPts > 0) {
                                if (response.minMandatoryPts > 0) {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                                }
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                            }
                        }
                        else {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                        }
                    }
                    var data = document.getElementById("Entitlement");
                    data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
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
        if (style.indexOf(',') > -1) {
            if (style.indexOf(',') > -1) {
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
                            if (response.Result.indexOf('points') > -1) {
                                if (response.availPts > 0) {
                                    if (response.minMandatoryPts > 0) {
                                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                    }
                                    else {
                                        errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded.  Cannot proceed.</span></div>";
                                    }
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                                }
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                            }
                        }
                        data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
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
                        if (response.Result.indexOf('points') > -1) {
                            if (response.availPts > 0) {
                                if (response.minMandatoryPts > 0) {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Minimum other mandatory points left to order " + response.minMandatoryPts + ".</span></div>";
                                }
                                else {
                                    errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                                }
                            }
                            else {
                                errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Entitlement points exceeded. Cannot proceed.</span></div>";
                            }
                        }
                        else {
                            errorMsg = "<div id='ErrorMessage'><span style=\"color:red\">Cannot proceed entitlement exceeded</span></div>";
                        }
                    }
                    data.innerHTML = response.Result.indexOf('points') > -1 ? response.Result.split("-////-")[0] + errorMsg : response.Result + errorMsg;
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
//$('.add-to-cart').on('click', function () {
//    var cart = $('.shopping-cart');
//    var imgtodrag = $(this).parent('.item').find("img").eq(0);
//    if (imgtodrag) {
//        var imgclone = imgtodrag.clone()
//            .offset({
//                top: imgtodrag.offset().top,
//                left: imgtodrag.offset().left
//            })
//            .css({
//                'opacity': '0.5',
//                'position': 'absolute',
//                'height': '150px',
//                'width': '150px',
//                'z-index': '100'
//            })
//            .appendTo($('body'))
//            .animate({
//                'top': cart.offset().top + 10,
//                'left': cart.offset().left + 10,
//                'width': 75,
//                'height': 75
//            }, 1000, 'easeInOutExpo');

//        setTimeout(function () {
//            cart.effect("shake", {
//                times: 2
//            }, 200);
//        }, 1500);

//        imgclone.animate({
//            'width': 0,
//            'height': 0
//        }, function () {
//            $(this).detach()
//        });
//    }
//});

function addTocartSwatchEmergency(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var sitecode = ASPxClientControl.GetControlCollection().GetByName("SiteCodeCmb");
    var selectedSitecode = sitecode != null ? sitecode.GetValue() != null ? sitecode.GetValue() : "" : "SITECODENULL";
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

    var reasonControl = ASPxClientControl.GetControlCollection().GetByName(reasonName)
    var reason = reasonControl == null ? "" : reasonControl.GetValue() == null ? "" : reasonControl.GetValue();

    //if (reasonControl.length > 0) {
    //    reason = reasonControl[0].value == "" | reasonControl[0].value == undefined ? reasonControl[0].defaultValue == "" | reasonControl[0].defaultValue == "" ? "" : reasonControl[0].defaultValue : reasonControl[0].value;
    //}
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

    if (stylearr[1].indexOf(',') > -1) {
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
    var minPtsDivName = "minPtsDiv_" + sStyle;
    var minPtsDiv = document.getElementsByClassName(minPtsDivName)
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = document.getElementsByName("spinEdit_" + stylearr[1]);
    var descriptionDiv = document.getElementById("LbDescription" + desc);
    description = descriptionDiv.innerHTML;
    var priceId = document.getElementById("LbPriceinput" + stylearr[1]);
    price = priceId != undefined && priceId != null ? priceId.value : priceId == undefined ? "0.0" : "0";
    qty = Spin[0].value;
    var clsName = "reqData" + stylearr[1];
    var reqdatatxt = "reqdatatxt" + stylearr[1];
    var reqData = document.getElementsByClassName(clsName);
    if (description != "" && price != "" && price != "0" && size != "" && color != "" && qty != "" && qty != "0" && (selectedSitecode != "" | selectedSitecode == "SITECODENULL")) {
        $.ajax({
            url: "/Home/GetBtnStatus/",
            type: "POST",
            data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
            success: function (response) {
                debugger;
                if (response == "enabled" && (reason != "" && reason != undefined)) {
                    loadPopup.Show();
                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                    $.ajax({
                        url: "/Home/Addtocart/",
                        type: "POST",
                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'reason': reason, 'selectedSitecode': selectedSitecode },
                        success: function (response) {
                            if (response != "") {
                                $("#CartwidCount").html("");
                                $("#CartwidCount").html(response);
                                loadPopup.Hide();
                                $.ajax({
                                    url: "/Home/GetFreeStockValue/",
                                    type: "POST",
                                    data: { 'StyleId': sStyle, 'ColorId': color, 'size': size },
                                    success: function (response) {
                                        if (response != "") {
                                            var Freestock = document.getElementById("FreeStcoker_" + sStyle + "_" + size + "");
                                            if (Freestock != null) {
                                                Freestock.innerHTML = response;
                                            }
                                        }
                                    }
                                });
                                myFunction("Added to cart..!");

                                //myFunction("Added to cart..!");  ;
                            }
                            else {
                                loadPopup.Hide();
                                $.ajax({
                                    url: "/Home/IsreasonFailed/",
                                    type: "POST",
                                    data: { 'reason': reason },
                                    success: function (response) {
                                        if (response != "") {
                                            alert(response);
                                        }
                                        else {
                                            alert("Try again..!");
                                        }

                                    }
                                });
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
                    if (reason == "" || reason == undefined) {
                        alert("Please enter a valid reason");
                    }
                    else {
                        // document.getElementById("ErrorMessage").style.display = 'block';
                        loadPopup.Hide();
                        getEntitlementSwatch(stylearr[1], stylearr[3], 1, size);
                    }

                }
            },
            error: function () {
                loadPopup.Hide();
                myFunction("Try again!");
            }
        });
    }
    else {
        if (price == "" || price == null || price == undefined || price == "0") {
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
        } else if (selectedSitecode == "") {
            alert("Please select a site code");
        }
        else if (reqtxt[0].value == "") {
            alert("Please select Required leg length");
        }

    }
}

function addTocartSwatch(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var sitecode = ASPxClientControl.GetControlCollection().GetByName("SiteCodeCmb");
    var selectedSitecode = sitecode != null ? sitecode.GetValue() != null ? sitecode.GetValue() : "" : "SITECODENULL";
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

    if (stylearr[1].indexOf(',') > -1) {
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
    var minPtsDivName = "minPtsDiv_" + sStyle;
    var minPtsDiv = document.getElementsByClassName(minPtsDivName)
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = document.getElementsByName("spinEdit_" + stylearr[1]);
    var descriptionDiv = document.getElementById("LbDescription" + desc);
    description = descriptionDiv.innerHTML;
    var priceId = document.getElementById("LbPriceinput" + stylearr[1]);
    price = priceId != undefined && priceId != null ? priceId.value : priceId == undefined ? "0.0" : "0";
    qty = Spin[0].value;
    var clsName = "reqData" + stylearr[1];
    var reqdatatxt = "reqdatatxt" + stylearr[1];
    var reqData = document.getElementsByClassName(clsName);
    if (reqData[0].style.display != "none") {
        var reqtxt = document.getElementsByClassName(reqdatatxt);
        if (description != "" && price != "" && price != "0" && size != "" && color != "" && qty != "" && qty != "0" && reqtxt[0].value != "" && (selectedSitecode != "" | selectedSitecode == "SITECODENULL")) {
            if (stylearr[2] != "") {
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            loadPopup.Show();
                            selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'reqData1': reqtxt[0].value, 'reason': reason, 'selectedSitecode': selectedSitecode },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        loadPopup.Hide();
                                        $.ajax({
                                            url: "/Home/GetPointsDiv/",
                                            type: "POST",
                                            data: { 'orgStyle': stylearr[3] },
                                            success: function (response) {
                                                if (response.PointsDiv != "") {
                                                    $("#PointsDiv").html("");
                                                    $("#PointsDiv").html(response.PointsDiv);
                                                    if (response.PointsTaken != "") {
                                                        var division = "minPtsDiv_" + stylearr[3];
                                                        var pts = document.getElementsByClassName(division);
                                                        if (pts != null && pts != undefined) {
                                                            for (var k = 0; k < pts.length; k++) {
                                                                pts[k].innerHTML = response.PointsTaken;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        });
                                        myFunction("Added to cart..!");

                                        //myFunction("Added to cart..!");  ;
                                    }
                                    else {
                                        loadPopup.Hide();
                                        $.ajax({
                                            url: "/Home/IsreasonFailed/",
                                            type: "POST",
                                            data: { 'reason': reason },
                                            success: function (response) {
                                                if (response != "") {
                                                    alert(response);
                                                }
                                                else {
                                                    alert("Try again..!");
                                                }

                                            }
                                        });
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
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1, size);

                        }
                    },
                    error: function () {
                        loadPopup.Hide();
                        myFunction("Try again!");
                    }
                });
            }
            else {
                loadPopup.Show();
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        $.ajax({
                                            url: "/Home/GetPointsDiv/",
                                            type: "POST",
                                            data: { 'orgStyle': stylearr[3] },
                                            success: function (response) {
                                                if (response.PointsDiv != "") {
                                                    $("#PointsDiv").html("");
                                                    $("#PointsDiv").html(response.PointsDiv);
                                                    if (response.PointsTaken != "") {
                                                        var division = "minPtsDiv_" + stylearr[3];
                                                        var pts = document.getElementsByClassName(division);
                                                        if (pts != null && pts != undefined) {
                                                            for (var k = 0; k < pts.length; k++) {
                                                                pts[k].innerHTML = response.PointsTaken;
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        });
                                        myFunction("Added to cart..!");

                                    }
                                    else {
                                        loadPopup.Hide();
                                        $.ajax({
                                            url: "/Home/IsreasonFailed/",
                                            type: "POST",
                                            data: { 'reason': reason },
                                            success: function (response) {
                                                if (response != "") {
                                                    alert(response);
                                                }
                                                else {
                                                    alert("Try again..!");
                                                }

                                            }
                                        });
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
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1, size);

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
            if (price == "" || price == null || price == undefined || price == "0") {
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
            } else if (selectedSitecode == "") {
                alert("Please select a site code");
            }
            else if (reqtxt[0].value == "") {
                alert("Please select Required leg length");
            }

        }
    }
    else {
        if (description != "" && price != "" && price != "0" && size != "" && color != "" && qty != "" && qty != "0" && (selectedSitecode != "" | selectedSitecode == "SITECODENULL")) {
            if (stylearr[2] != "") {
                $.ajax({
                    url: "/Home/GetBtnStatus/",
                    type: "POST",
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            loadPopup.Show();
                            selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'entQty': stylearr[2], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        loadPopup.Hide();
                                        $.ajax({
                                            url: "/Home/GetPointsDiv/",
                                            type: "POST",
                                            data: { 'orgStyle': stylearr[3] },
                                            success: function (response) {
                                                if (response.PointsDiv != "") {
                                                    $("#PointsDiv").html("");
                                                    $("#PointsDiv").html(response.PointsDiv);
                                                    if (response.PointsTaken != "") {
                                                        var division = "minPtsDiv_" + stylearr[3];
                                                        var pts = document.getElementsByClassName(division);
                                                        if (pts != null && pts != undefined) {
                                                            for (var k = 0; k < pts.length; k++) {
                                                                pts[k].innerHTML = response.PointsTaken;
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        });
                                        myFunction("Added to cart..!");

                                        //myFunction("Added to cart..!");  ;
                                    }
                                    else {
                                        loadPopup.Hide();
                                        $.ajax({
                                            url: "/Home/IsreasonFailed/",
                                            type: "POST",
                                            data: { 'reason': reason },
                                            success: function (response) {
                                                if (response != "") {
                                                    alert(response);
                                                }
                                                else {
                                                    alert("Try again..!");
                                                }

                                            }
                                        });
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
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1, size);

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
                    data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                    success: function (response) {
                        debugger;
                        if (response == "enabled" | (reason != "" && reason != undefined)) {
                            selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                            $.ajax({
                                url: "/Home/Addtocart/",
                                type: "POST",
                                data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                success: function (response) {
                                    if (response != "") {
                                        $("#CartwidCount").html("");
                                        $("#CartwidCount").html(response);
                                        $.ajax({
                                            url: "/Home/GetPointsDiv/",
                                            type: "POST",
                                            data: { 'orgStyle': stylearr[3] },
                                            success: function (response) {
                                                if (response.PointsDiv != "") {
                                                    $("#PointsDiv").html("");
                                                    $("#PointsDiv").html(response.PointsDiv);
                                                    if (response.PointsTaken != "") {
                                                        var division = "minPtsDiv_" + stylearr[3];
                                                        var pts = document.getElementsByClassName(division);
                                                        if (pts != null && pts != undefined) {
                                                            for (var k = 0; k < pts.length; k++) {
                                                                pts[k].innerHTML = response.PointsTaken;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        });
                                        myFunction("Added to cart..!");

                                    }
                                    else {
                                        loadPopup.Hide();
                                        $.ajax({
                                            url: "/Home/IsreasonFailed/",
                                            type: "POST",
                                            data: { 'reason': reason },
                                            success: function (response) {
                                                if (response != "") {
                                                    alert(response);
                                                }
                                                else {
                                                    alert("Try again..!");
                                                }

                                            }
                                        });
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
                            getEntitlementSwatch(stylearr[1], stylearr[3], 1, size);

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
            if (price == "" || price == null || price == undefined || price == "0") {
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
            else if (selectedSitecode == "") {
                alert("Please select a site code");
            }
            else if (reqtxt[0].value == "") {
                alert("Please select Required leg length");
            }
        }
    }
}

function PointsEndCallBack() {

    $.ajax({
        type: "post",
        url: "/Home/GetPointsDiv/",
        success: function (resp) {
            if (resp.PointsDiv != "") {
                $("#PointsDiv").html("");
                $("#PointsDiv").html(resp.PointsDiv);
            }
        }
    });
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

    if (stylearr[1].indexOf(',') > -1) {
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
                data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'size': size },
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
                data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'size': size },
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
        } else if (selectedSitecode == "") {
            alert("Please select a site code");
        }
        else if (reqtxt[0].value == "") {
            alert("Please select Required leg length");
        }
    }
}

function AddClientCode(s, e) {
    var sitecode = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var sitecodeVal = sitecode.GetValue();
    if (sitecodeVal != null && sitecodeVal != "") {
        $.ajax({
            url: "/Home/SetClientcode/",
            type: "POST",
            data: { 'SetClientcode': sitecodeVal },
            success: function (resp) {
            }
        });
    }
}
function SetSopDetail5(s, e) {
    var sitecode = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var sitecodeVal = sitecode.GetValue();
    if (sitecodeVal != null && sitecodeVal != "") {
        $.ajax({
            url: "/Basket/SetSopDetail5/",
            type: "POST",
            data: { 'SetClientcode': sitecodeVal },
            success: function (resp) {
            }
        });
    }
}

//

function addTocartDemandSwatch(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var sitecode = ASPxClientControl.GetControlCollection().GetByName("SiteCodeCmbgroupedProducts");
    var selectedSitecode = sitecode != null ? sitecode.GetValue() != null ? sitecode.GetValue() : "" : "SITECODENULL";
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

    if (stylearr[1].indexOf(',') > -1) {
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
    var minPtsDivName = "minPtsDiv_" + stylearr[3];
    var minPtsDiv = document.getElementsByClassName(minPtsDivName)
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = document.getElementsByName("spinDemandEdit_" + stylearr[1]);
    var priceId = document.getElementById("DimviewPriceinput1" + stylearr[1]);
    description = document.getElementById("LbdemandDescription" + desc).innerHTML;
    price = priceId != undefined && priceId != null ? priceId.value : priceId == undefined ? "0.0" : "0"; "0";
    qty = Spin[0].value;
    var clsName = "reqDatadim" + stylearr[1];
    var reqdatatxt = "reqdatatxtdim" + stylearr[1];
    var reqData = document.getElementsByClassName(clsName);

    if (s.name.indexOf("Reorder") > -1) {
        if (description != "" && price != "" && price != "0" && size != undefined && price != undefined && color != undefined && size != "" && color != "" && qty != "" && qty != "0" && reqtxt[0].value != "" && (selectedSitecode != "" | selectedSitecode == "SITECODENULL")) {
        }

    }
    else {
        if (reqData[0].style.display != "none") {
            var reqtxt = document.getElementsByClassName(reqdatatxt);
            if (description != "" && price != "" && price != "0" && size != undefined && price != undefined && color != undefined && size != "" && color != "" && qty != "" && qty != "0" && reqtxt[0].value != "" && (selectedSitecode != "" | selectedSitecode == "SITECODENULL")) {
                if (stylearr[2] != "") {
                    $.ajax({
                        url: "/Home/GetBtnStatus/",
                        type: "POST",
                        data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                        success: function (response) {
                            debugger;
                            if (response == "enabled" | (reason != "" && reason != undefined)) {
                                if (minPtsDiv != undefined || minPtsDiv != null) {
                                    $.ajax({
                                        url: "/Home/UpdateMinPoints/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response.message != "" && response.message != null) {
                                                if (response.message.indexOf("__ALERT__") > -1) {
                                                    var cnfmessage = response.message.split("__ALERT__")[1] + "\n\nPlease click Ok to proceed to cart or Cancel to continue shopping";
                                                    if (confirm(cnfmessage)) {
                                                        loadPopup.Show();
                                                        selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                                        $.ajax({
                                                            url: "/Home/Addtocart/",
                                                            type: "POST",
                                                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reqData1': reqtxt[0].value, 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                            success: function (response) {
                                                                if (response != "") {
                                                                    $("#CartwidCount").html("");
                                                                    $("#CartwidCount").html(response);
                                                                    loadPopup.Hide();
                                                                    $.ajax({
                                                                        url: "/Home/GetPointsDiv/",
                                                                        type: "POST",
                                                                        data: { 'orgStyle': stylearr[3] },
                                                                        success: function (response) {
                                                                            if (response.PointsDiv != "") {
                                                                                $("#PointsDiv").html("");
                                                                                $("#PointsDiv").html(response.PointsDiv);
                                                                                if (response.PointsTaken != "") {
                                                                                    var division = "minPtsDiv_" + stylearr[3];
                                                                                    var pts = document.getElementsByClassName(division);
                                                                                    if (pts != null && pts != undefined) {
                                                                                        for (var k = 0; k < pts.length; k++) {
                                                                                            pts[k].innerHTML = response.PointsTaken;
                                                                                        }
                                                                                    }
                                                                                }

                                                                            }
                                                                        }
                                                                    });
                                                                    myFunction("Added to cart..!");
                                                                }
                                                                else {
                                                                    loadPopup.Hide();
                                                                    $.ajax({
                                                                        url: "/Home/IsreasonFailed/",
                                                                        type: "POST",
                                                                        data: { 'reason': reason },
                                                                        success: function (response) {
                                                                            if (response != "") {
                                                                                alert(response);
                                                                            }
                                                                            else {
                                                                                alert("Try again..!");
                                                                            }

                                                                        }
                                                                    });
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
                                                    if (response.pointsStyle.length > 0) {
                                                        for (var k = 0; k < response.pointsStyle.length; k++) {
                                                            var idMinPts = "minPtsDiv_" + response.pointsStyle[k];
                                                            var pointsDivReplace = document.getElementsByClassName(idMinPts);
                                                            if (pointsDivReplace != undefined && pointsDivReplace != null && pointsDivReplace != "") {
                                                                for (var j = 0; j < pointsDivReplace.length; j++) {
                                                                    pointsDivReplace[j].innerHTML = response.message;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    loadPopup.Show();
                                                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                                    $.ajax({
                                                        url: "/Home/Addtocart/",
                                                        type: "POST",
                                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reqData1': reqtxt[0].value, 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                        success: function (response) {
                                                            if (response != "") {
                                                                $("#CartwidCount").html("");
                                                                $("#CartwidCount").html(response);
                                                                loadPopup.Hide();
                                                                $.ajax({
                                                                    url: "/Home/GetPointsDiv/",
                                                                    type: "POST",
                                                                    data: { 'orgStyle': stylearr[3] },
                                                                    success: function (response) {
                                                                        if (response.PointsDiv != "") {
                                                                            $("#PointsDiv").html("");
                                                                            $("#PointsDiv").html(response.PointsDiv);
                                                                            if (response.PointsTaken != "") {
                                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                                var pts = document.getElementsByClassName(division);
                                                                                if (pts != null && pts != undefined) {
                                                                                    for (var k = 0; k < pts.length; k++) {
                                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                                    }
                                                                                }
                                                                            }

                                                                        }
                                                                    }
                                                                });
                                                                myFunction("Added to cart..!");
                                                            }
                                                            else {
                                                                loadPopup.Hide();
                                                                $.ajax({
                                                                    url: "/Home/IsreasonFailed/",
                                                                    type: "POST",
                                                                    data: { 'reason': reason },
                                                                    success: function (response) {
                                                                        if (response != "") {
                                                                            alert(response);
                                                                        }
                                                                        else {
                                                                            alert("Try again..!");
                                                                        }

                                                                    }
                                                                });
                                                            }
                                                        },
                                                        error: function () {
                                                            loadPopup.Hide();
                                                            alert("Try again!");
                                                        }
                                                    });

                                                }
                                            }
                                        }
                                    });
                                }
                                else {
                                    loadPopup.Show();
                                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                    $.ajax({
                                        url: "/Home/Addtocart/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reqData1': reqtxt[0].value, 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response != "") {
                                                $("#CartwidCount").html("");
                                                $("#CartwidCount").html(response);
                                                loadPopup.Hide();
                                                $.ajax({
                                                    url: "/Home/GetPointsDiv/",
                                                    type: "POST",
                                                    data: { 'orgStyle': stylearr[3] },
                                                    success: function (response) {
                                                        if (response.PointsDiv != "") {
                                                            $("#PointsDiv").html("");
                                                            $("#PointsDiv").html(response.PointsDiv);
                                                            if (response.PointsTaken != "") {
                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                var pts = document.getElementsByClassName(division);
                                                                if (pts != null && pts != undefined) {
                                                                    for (var k = 0; k < pts.length; k++) {
                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                });
                                                myFunction("Added to cart..!");
                                            }
                                            else {
                                                loadPopup.Hide();
                                                $.ajax({
                                                    url: "/Home/IsreasonFailed/",
                                                    type: "POST",
                                                    data: { 'reason': reason },
                                                    success: function (response) {
                                                        if (response != "") {
                                                            alert(response);
                                                        }
                                                        else {
                                                            alert("Try again..!");
                                                        }

                                                    }
                                                });
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

                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                    $.ajax({
                        url: "/Home/GetBtnStatus/",
                        type: "POST",
                        data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                        success: function (response) {
                            if (response == "enabled" | (reason != "" && reason != undefined)) {
                                if (minPtsDiv != undefined || minPtsDiv != null) {
                                    $.ajax({
                                        url: "/Home/UpdateMinPoints/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response.message != "" && response.message != null) {
                                                if (response.message.indexOf("__ALERT__") > -1) {
                                                    var cnfmessage = response.message.split("__ALERT__")[1] + "\n\nPlease click Ok to proceed to cart or Cancel to continue shopping";
                                                    if (confirm(response.message.split("__ALERT__")[1])) {
                                                        $.ajax({
                                                            url: "/Home/Addtocart/",
                                                            type: "POST",
                                                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                            success: function (response) {
                                                                if (response != "") {
                                                                    $("#CartwidCount").html("");
                                                                    $("#CartwidCount").html(response);
                                                                    $.ajax({
                                                                        url: "/Home/GetPointsDiv/",
                                                                        type: "POST",
                                                                        data: { 'orgStyle': stylearr[3] },
                                                                        success: function (response) {
                                                                            if (response.PointsDiv != "") {
                                                                                $("#PointsDiv").html("");
                                                                                $("#PointsDiv").html(response.PointsDiv);
                                                                                if (response.PointsTaken != "") {
                                                                                    var division = "minPtsDiv_" + stylearr[3];
                                                                                    var pts = document.getElementsByClassName(division);
                                                                                    if (pts != null && pts != undefined) {
                                                                                        for (var k = 0; k < pts.length; k++) {
                                                                                            pts[k].innerHTML = response.PointsTaken;
                                                                                        }
                                                                                    }
                                                                                }

                                                                            }
                                                                        }
                                                                    });
                                                                    myFunction("Added to cart..!");

                                                                }
                                                                else {
                                                                    loadPopup.Hide();
                                                                    $.ajax({
                                                                        url: "/Home/IsreasonFailed/",
                                                                        type: "POST",
                                                                        data: { 'reason': reason },
                                                                        success: function (response) {
                                                                            if (response != "") {
                                                                                alert(response);
                                                                            }
                                                                            else {
                                                                                alert("Try again..!");
                                                                            }

                                                                        }
                                                                    });
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
                                                    if (response.pointsStyle.length > 0) {
                                                        for (var k = 0; k < response.pointsStyle.length; k++) {
                                                            var idMinPts = "minPtsDiv_" + response.pointsStyle[k];
                                                            var pointsDivReplace = document.getElementsByClassName(idMinPts);
                                                            if (pointsDivReplace != undefined && pointsDivReplace != null && pointsDivReplace != "") {
                                                                for (var j = 0; j < pointsDivReplace.length; j++) {
                                                                    pointsDivReplace[j].innerHTML = response.message;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    $.ajax({
                                                        url: "/Home/Addtocart/",
                                                        type: "POST",
                                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                        success: function (response) {
                                                            if (response != "") {
                                                                $("#CartwidCount").html("");
                                                                $("#CartwidCount").html(response);
                                                                $.ajax({
                                                                    url: "/Home/GetPointsDiv/",
                                                                    type: "POST",
                                                                    data: { 'orgStyle': stylearr[3] },
                                                                    success: function (response) {
                                                                        if (response.PointsDiv != "") {
                                                                            $("#PointsDiv").html("");
                                                                            $("#PointsDiv").html(response.PointsDiv);
                                                                            if (response.PointsTaken != "") {
                                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                                var pts = document.getElementsByClassName(division);
                                                                                if (pts != null && pts != undefined) {
                                                                                    for (var k = 0; k < pts.length; k++) {
                                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                                    }
                                                                                }
                                                                            }

                                                                        }
                                                                    }
                                                                });
                                                                myFunction("Added to cart..!");

                                                            }
                                                            else {
                                                                loadPopup.Hide();
                                                                $.ajax({
                                                                    url: "/Home/IsreasonFailed/",
                                                                    type: "POST",
                                                                    data: { 'reason': reason },
                                                                    success: function (response) {
                                                                        if (response != "") {
                                                                            alert(response);
                                                                        }
                                                                        else {
                                                                            alert("Try again..!");
                                                                        }

                                                                    }
                                                                });
                                                            }
                                                        },
                                                        error: function () {
                                                            loadPopup.Hide();
                                                            alert("Try again!");
                                                        }
                                                    });
                                                }
                                            }
                                        }
                                    });
                                }
                                else {
                                    $.ajax({
                                        url: "/Home/Addtocart/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response != "") {
                                                $("#CartwidCount").html("");
                                                $("#CartwidCount").html(response);
                                                $.ajax({
                                                    url: "/Home/GetPointsDiv/",
                                                    type: "POST",
                                                    data: { 'orgStyle': stylearr[3] },
                                                    success: function (response) {
                                                        if (response.PointsDiv != "") {
                                                            $("#PointsDiv").html("");
                                                            $("#PointsDiv").html(response.PointsDiv);
                                                            if (response.PointsTaken != "") {
                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                var pts = document.getElementsByClassName(division);
                                                                if (pts != null && pts != undefined) {
                                                                    for (var k = 0; k < pts.length; k++) {
                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                });
                                                myFunction("Added to cart..!");

                                            }
                                            else {
                                                loadPopup.Hide();
                                                $.ajax({
                                                    url: "/Home/IsreasonFailed/",
                                                    type: "POST",
                                                    data: { 'reason': reason },
                                                    success: function (response) {
                                                        if (response != "") {
                                                            alert(response);
                                                        }
                                                        else {
                                                            alert("Try again..!");
                                                        }

                                                    }
                                                });
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
                if (price == "" || price == null || price == undefined || price == "0") {
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
                } else if (selectedSitecode == "") {
                    alert("Please select a site code");
                }
                else if (reqtxt[0].value == "") {
                    alert("Please select Required leg length");
                }
            }
        }
        else {
            if (description != "" && price != "" && price != "0" && size != undefined && price != undefined && color != undefined && size != "" && color != "" && qty != "" && qty != "0" && (selectedSitecode != "" | selectedSitecode == "SITECODENULL")) {
                if (stylearr[2] != "") {

                    $.ajax({
                        url: "/Home/GetBtnStatus/",
                        type: "POST",
                        data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                        success: function (response) {
                            debugger;
                            if (response == "enabled" | (reason != "" && reason != undefined)) {
                                if (minPtsDiv != undefined || minPtsDiv != null) {
                                    $.ajax({
                                        url: "/Home/UpdateMinPoints/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response.message != "" && response.message != null) {
                                                if (response.message.indexOf("__ALERT__") > -1) {
                                                    var cnfmessage = response.message.split("__ALERT__")[1] + "\n\nPlease click Ok to proceed to cart or Cancel to continue shopping";
                                                    if (confirm(cnfmessage)) {
                                                        loadPopup.Show();
                                                        selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                                        $.ajax({
                                                            url: "/Home/Addtocart/",
                                                            type: "POST",
                                                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                            success: function (response) {
                                                                if (response != "") {
                                                                    $("#CartwidCount").html("");
                                                                    $("#CartwidCount").html(response);
                                                                    loadPopup.Hide();
                                                                    $.ajax({
                                                                        url: "/Home/GetPointsDiv/",
                                                                        type: "POST",
                                                                        data: { 'orgStyle': stylearr[3] },
                                                                        success: function (response) {
                                                                            if (response.PointsDiv != "") {
                                                                                $("#PointsDiv").html("");
                                                                                $("#PointsDiv").html(response.PointsDiv);
                                                                                if (response.PointsTaken != "") {
                                                                                    var division = "minPtsDiv_" + stylearr[3];
                                                                                    var pts = document.getElementsByClassName(division);
                                                                                    if (pts != null && pts != undefined) {
                                                                                        for (var k = 0; k < pts.length; k++) {
                                                                                            pts[k].innerHTML = response.PointsTaken;
                                                                                        }
                                                                                    }
                                                                                }

                                                                            }
                                                                        }
                                                                    });
                                                                    myFunction("Added to cart..!");

                                                                }
                                                                else {
                                                                    loadPopup.Hide();
                                                                    $.ajax({
                                                                        url: "/Home/IsreasonFailed/",
                                                                        type: "POST",
                                                                        data: { 'reason': reason },
                                                                        success: function (response) {
                                                                            if (response != "") {
                                                                                alert(response);
                                                                            }
                                                                            else {
                                                                                alert("Try again..!");
                                                                            }

                                                                        }
                                                                    });
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

                                                    if (response.pointsStyle.length > 0) {
                                                        for (var k = 0; k < response.pointsStyle.length; k++) {
                                                            var idMinPts = "minPtsDiv_" + response.pointsStyle[k];
                                                            var pointsDivReplace = document.getElementsByClassName(idMinPts);
                                                            if (pointsDivReplace != undefined && pointsDivReplace != null && pointsDivReplace != "") {
                                                                for (var j = 0; j < pointsDivReplace.length; j++) {
                                                                    pointsDivReplace[j].innerHTML = response.message;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    loadPopup.Show();
                                                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                                    $.ajax({
                                                        url: "/Home/Addtocart/",
                                                        type: "POST",
                                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                        success: function (response) {
                                                            if (response != "") {
                                                                $("#CartwidCount").html("");
                                                                $("#CartwidCount").html(response);
                                                                loadPopup.Hide();
                                                                $.ajax({
                                                                    url: "/Home/GetPointsDiv/",
                                                                    type: "POST",
                                                                    data: { 'orgStyle': stylearr[3] },
                                                                    success: function (response) {
                                                                        if (response.PointsDiv != "") {
                                                                            $("#PointsDiv").html("");
                                                                            $("#PointsDiv").html(response.PointsDiv);
                                                                            if (response.PointsTaken != "") {
                                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                                var pts = document.getElementsByClassName(division);
                                                                                if (pts != null && pts != undefined) {
                                                                                    for (var k = 0; k < pts.length; k++) {
                                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                                    }
                                                                                }
                                                                            }

                                                                        }
                                                                    }
                                                                });
                                                                myFunction("Added to cart..!");

                                                            }
                                                            else {
                                                                loadPopup.Hide();
                                                                $.ajax({
                                                                    url: "/Home/IsreasonFailed/",
                                                                    type: "POST",
                                                                    data: { 'reason': reason },
                                                                    success: function (response) {
                                                                        if (response != "") {
                                                                            alert(response);
                                                                        }
                                                                        else {
                                                                            alert("Try again..!");
                                                                        }

                                                                    }
                                                                });
                                                            }
                                                        },
                                                        error: function () {
                                                            loadPopup.Hide();
                                                            alert("Try again!");
                                                        }
                                                    });
                                                }

                                            }
                                        }

                                    });
                                }
                                else {
                                    loadPopup.Show();
                                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                    $.ajax({
                                        url: "/Home/Addtocart/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response != "") {
                                                $("#CartwidCount").html("");
                                                $("#CartwidCount").html(response);
                                                loadPopup.Hide();
                                                $.ajax({
                                                    url: "/Home/GetPointsDiv/",
                                                    type: "POST",
                                                    data: { 'orgStyle': stylearr[3] },
                                                    success: function (response) {
                                                        if (response.PointsDiv != "") {
                                                            $("#PointsDiv").html("");
                                                            $("#PointsDiv").html(response.PointsDiv);
                                                            if (response.PointsTaken != "") {
                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                var pts = document.getElementsByClassName(division);
                                                                if (pts != null && pts != undefined) {
                                                                    for (var k = 0; k < pts.length; k++) {
                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                });
                                                myFunction("Added to cart..!");

                                            }
                                            else {
                                                loadPopup.Hide();
                                                $.ajax({
                                                    url: "/Home/IsreasonFailed/",
                                                    type: "POST",
                                                    data: { 'reason': reason },
                                                    success: function (response) {
                                                        if (response != "") {
                                                            alert(response);
                                                        }
                                                        else {
                                                            alert("Try again..!");
                                                        }

                                                    }
                                                });
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
                        data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3], 'size': size },
                        success: function (response) {
                            debugger;
                            if (response == "enabled" | (reason != "" && reason != undefined)) {
                                if (minPtsDiv != undefined || minPtsDiv != null) {
                                    $.ajax({
                                        url: "/Home/UpdateMinPoints/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response.message != "" && response.message != null) {
                                                if (response.message.indexOf("__ALERT__") > -1) {
                                                    var cnfmessage = response.message.split("__ALERT__")[1] + "\n\nPlease click Ok to proceed to cart or Cancel to continue shopping";
                                                    if (confirm(cnfmessage)) {
                                                        selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                                        $.ajax({
                                                            url: "/Home/Addtocart/",
                                                            type: "POST",
                                                            data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                            success: function (response) {
                                                                if (response != "") {
                                                                    $("#CartwidCount").html("");
                                                                    $("#CartwidCount").html(response);
                                                                    $.ajax({
                                                                        url: "/Home/GetPointsDiv/",
                                                                        type: "POST",
                                                                        data: { 'orgStyle': stylearr[3] },
                                                                        success: function (response) {
                                                                            if (response.PointsDiv != "") {
                                                                                $("#PointsDiv").html("");
                                                                                $("#PointsDiv").html(response.PointsDiv);
                                                                                if (response.PointsTaken != "") {
                                                                                    var division = "minPtsDiv_" + stylearr[3];
                                                                                    var pts = document.getElementsByClassName(division);
                                                                                    if (pts != null && pts != undefined) {
                                                                                        for (var k = 0; k < pts.length; k++) {
                                                                                            pts[k].innerHTML = response.PointsTaken;
                                                                                        }
                                                                                    }
                                                                                }

                                                                            }
                                                                        }
                                                                    });
                                                                    myFunction("Added to cart..!");

                                                                }
                                                                else {
                                                                    loadPopup.Hide();
                                                                    $.ajax({
                                                                        url: "/Home/IsreasonFailed/",
                                                                        type: "POST",
                                                                        data: { 'reason': reason },
                                                                        success: function (response) {
                                                                            if (response != "") {
                                                                                alert(response);
                                                                            }
                                                                            else {
                                                                                alert("Try again..!");
                                                                            }

                                                                        }
                                                                    });
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
                                                    if (response.pointsStyle.length > 0) {
                                                        for (var k = 0; k < response.pointsStyle.length; k++) {
                                                            var idMinPts = "minPtsDiv_" + response.pointsStyle[k];
                                                            var pointsDivReplace = document.getElementsByClassName(idMinPts);
                                                            if (pointsDivReplace != undefined && pointsDivReplace != null && pointsDivReplace != "") {
                                                                for (var j = 0; j < pointsDivReplace.length; j++) {
                                                                    pointsDivReplace[j].innerHTML = response.message;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                                    $.ajax({
                                                        url: "/Home/Addtocart/",
                                                        type: "POST",
                                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                                        success: function (response) {
                                                            if (response != "") {
                                                                $("#CartwidCount").html("");
                                                                $("#CartwidCount").html(response);
                                                                $.ajax({
                                                                    url: "/Home/GetPointsDiv/",
                                                                    type: "POST",
                                                                    data: { 'orgStyle': stylearr[3] },
                                                                    success: function (response) {
                                                                        if (response.PointsDiv != "") {
                                                                            $("#PointsDiv").html("");
                                                                            $("#PointsDiv").html(response.PointsDiv);
                                                                            if (response.PointsTaken != "") {
                                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                                var pts = document.getElementsByClassName(division);
                                                                                if (pts != null && pts != undefined) {
                                                                                    for (var k = 0; k < pts.length; k++) {
                                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                                    }
                                                                                }
                                                                            }

                                                                        }
                                                                    }
                                                                });
                                                                myFunction("Added to cart..!");

                                                            }
                                                            else {
                                                                loadPopup.Hide();
                                                                $.ajax({
                                                                    url: "/Home/IsreasonFailed/",
                                                                    type: "POST",
                                                                    data: { 'reason': reason },
                                                                    success: function (response) {
                                                                        if (response != "") {
                                                                            alert(response);
                                                                        }
                                                                        else {
                                                                            alert("Try again..!");
                                                                        }

                                                                    }
                                                                });
                                                            }
                                                        },
                                                        error: function () {
                                                            loadPopup.Hide();
                                                            alert("Try again!");
                                                        }
                                                    });
                                                }
                                            }
                                        }
                                    });
                                }
                                else {
                                    selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
                                    $.ajax({
                                        url: "/Home/Addtocart/",
                                        type: "POST",
                                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                                        success: function (response) {
                                            if (response != "") {
                                                $("#CartwidCount").html("");
                                                $("#CartwidCount").html(response);
                                                $.ajax({
                                                    url: "/Home/GetPointsDiv/",
                                                    type: "POST",
                                                    data: { 'orgStyle': stylearr[3] },
                                                    success: function (response) {
                                                        if (response.PointsDiv != "") {
                                                            $("#PointsDiv").html("");
                                                            $("#PointsDiv").html(response.PointsDiv);
                                                            if (response.PointsTaken != "") {
                                                                var division = "minPtsDiv_" + stylearr[3];
                                                                var pts = document.getElementsByClassName(division);
                                                                if (pts != null && pts != undefined) {
                                                                    for (var k = 0; k < pts.length; k++) {
                                                                        pts[k].innerHTML = response.PointsTaken;
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                });
                                                myFunction("Added to cart..!");

                                            }
                                            else {
                                                loadPopup.Hide();
                                                $.ajax({
                                                    url: "/Home/IsreasonFailed/",
                                                    type: "POST",
                                                    data: { 'reason': reason },
                                                    success: function (response) {
                                                        if (response != "") {
                                                            alert(response);
                                                        }
                                                        else {
                                                            alert("Try again..!");
                                                        }

                                                    }
                                                });
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
                if (price == "" || price == null || price == undefined || price == "0") {
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
                } else if (selectedSitecode == "") {
                    alert("Please select a site code");
                }
                else if (reqtxt[0].value == "") {
                    alert("Please select Required leg length");
                }
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
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_demand_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" placeholder='Quantity'  id='" + stle + "_demand_" + response.PriceList[i].Size + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
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
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_demand_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
                                            }
                                            else {
                                                sizContent = sizContent + "<div class='col-md-4  BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-4'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-4'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-4'><center><input type =\"number\" id='" + stle + "_demand_" + response.PriceList[i].Size + "'  placeholder='Quantity'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
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
                            var priceId = "DimviewPriceinput1" + style_nam;
                            var price = document.getElementById(priceId);
                            price.value = "";
                            price.value = resp.price == null ? "" : resp.price;
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
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_demand_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
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
                                                sizContent = sizContent + "<div class='col-md-4 BulkOrder1_Demand_" + stle + "' style=\"margin-bottom:10px;border: solid 1px;padding: 15px;\"><div class='row'><div class='col-md-3'><center>" + response.PriceList[i].Size + "</center></div><div class='col-md-3'><center>" + response.PriceList[i].Currency + " " + response.PriceList[i].Price + "</center></div><div class='col-md-3'><center><input type =\"number\" placeholder='Quantity'   min=\"0\" id='" + stle + "_demand_" + response.PriceList[i].Size + "'   class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div><div class='col-md-3'><center><input type =\"text\" id='ReqData_" + stle + "_" + response.PriceList[i].Size + "' placeholder='" + response.ReqData + "'  min=\"0\"  class=\"form-control\" style=\"width:100%; text-align: center; \"/></center></div></div></div>";
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
    var style_nam = s.name.indexOf("styleDimDrp_") > -1 ? s.name.replace("styleDimDrp_", "") : s.name;
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
    var style_nam = s.name.indexOf("styleDimviewDrp_") > -1 ? s.name.replace("styleDimviewDrp_", "") : s.name;
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
                if (!response.indexOf("Login") > -1) {
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
    if (style.indexOf(",") > -1) {
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
                if (!response.indexOf("Login") > -1) {
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
    if (stylearr[1].indexOf(',') > -1) {
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
                if (!response.indexOf("Login") > -1) {
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
function DeleteOrderwithreason() {
    var ordernoInp = document.getElementById("txtOrderNoVal");
    var isEmergencyInp = document.getElementById("txtOrderTypeVal");
    var empIdInp = document.getElementById("txtEmpIdVal");
    var orderno = ordernoInp.value == null | ordernoInp.value == "" ? 0 : parseInt(ordernoInp.value);
    var empId = empIdInp.value == null | empIdInp.value == "" ? "" : empIdInp.value;
    var emerReason = ASPxClientControl.GetControlCollection().GetByName("txtReasonEmer");
    var reason = emerReason.GetValue() == null | emerReason.GetValue() == "" ? "" : emerReason.GetValue();
    if (reason != "") {
        if (orderno > 0 && empId != "") {
            DeleteOrder(orderno, empId, false, reason);
        }
    }
    else {
        alert("Please enter a valid reason to delete the order");
    }
}

function DeleteReturnOrders(orderNo) {
    if (orderNo > 0) {
        if (confirm("Are you sure you want to delete this order?")) {
            var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
            loadPopup.Show();
            $.ajax({
                type: "post",
                url: "/Return/DeleteReturnOrders/",
                data: { 'orderNo': orderNo },
                success: function (response) {
                    if (response == "Success") {
                        loadPopup.Hide();
                        alert("Order deleted successfully");
                        window.location.reload();
                    }
                    else {
                        loadPopup.Hide();
                        alert("Please try again ");
                    }
                }
            });
        }
    }
}
function DeleteOrder(orderNo, empId, isEmergency, reason) {
    if (orderNo > 0 && empId != "" && empId != null) {
        if (confirm("Are you sure you want to delete this order?")) {
            // var model = { 'Ordeno': orderNo, 'EmployeeId': empId, 'isEmergency': isEmergency };
            var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
            loadPopup.Show();
            $.ajax({
                type: "post",
                url: "/Basket/DeleteOrder/",
                data: { 'orderNo': orderNo, 'empId': empId, 'isEmergency': isEmergency, 'reason': reason },
                success: function (response) {
                    if (response == "Success") {
                        loadPopup.Hide();
                        alert("Order deleted successfully");
                        window.location.reload();
                    }
                    else if (response == "prompt") {
                        $.ajax({
                            type: "post",
                            url: "/Basket/DeleteOrderPrompt/",
                            data: { 'orderNo': orderNo },
                            success: function (response) {
                                var popup = ASPxClientControl.GetControlCollection().GetByName("EmerOrderDeletePopup");
                                var docValue = document.getElementById("deletereason");
                                docValue.innerHTML = response;
                                loadPopup.Hide();
                                popup.Show();
                                MVCxClientUtils.FinalizeCallback();
                            }
                        }
                            );
                    }
                    else {
                        loadPopup.Hide();
                    }
                }
            });
        }
    }
}

function CloseDelReasonPOP() {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");

    var popup = ASPxClientControl.GetControlCollection().GetByName("EmerOrderDeletePopup");
    loadPopup.Hide();
    popup.Hide()
}
function SetAddressChange() {
    $.ajax(
        {
            url: "/Employee/SetAddressChange/",
            type: "post",
            success: function () {
            }
        }
        )
}
function matchPwd() {
    var newPwd = "";
    var cnfPwd = "";
    var newPwdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtNewPwd");
    var newPwdCtrl1 = ASPxClientControl.GetControlCollection().GetByName("txtNewPwd1");
    var cnfPwdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtCnfNewPwd");
    var cnfPwdCtrl1 = ASPxClientControl.GetControlCollection().GetByName("txtCnfNewPwd1");
    if (newPwdCtrl.GetVisible()) {
        newPwd = newPwdCtrl == null ? "" : newPwdCtrl.GetValue();
    }
    else if (newPwdCtrl1.GetVisible()) {
        newPwd = newPwdCtrl1 == null ? "" : newPwdCtrl1.GetValue();
    }
    if (cnfPwdCtrl.GetVisible()) {
        cnfPwd = cnfPwdCtrl == null ? "" : cnfPwdCtrl.GetValue();
    }
    else if (cnfPwdCtrl1.GetVisible()) {
        cnfPwd = cnfPwdCtrl1 == null ? "" : cnfPwdCtrl1.GetValue();
    }
    if (newPwd != cnfPwd) {
        document.getElementById('message').style.color = 'red';
        document.getElementById('message').innerHTML = 'Confirm password does not match';
    }
    else {
        document.getElementById('message').style.color = 'red';
        document.getElementById('message').innerHTML = '';
    }
}

function showpwd(field) {
    var field1 = field + "1";
    var pwd = ASPxClientControl.GetControlCollection().GetByName(field);
    var pwd1 = ASPxClientControl.GetControlCollection().GetByName(field1);
    var value = "";
    var error1 = field + "1_EC";
    var error = field + "_EC";
    value = value == null ? "" : value;
    if (pwd1.GetVisible()) {
        value = pwd1 == null ? "" : pwd1.GetValue();
        document.getElementById(error1).style.visibility = "hidden";
        document.getElementById(error).style.visibility = "visible";
        pwd.SetVisible(true);
        pwd1.SetVisible(false);
        pwd1.SetValue(value);
        pwd.SetValue(value);
    }
    else {
        value = pwd == null ? "" : pwd.GetValue();
        document.getElementById(error).style.visibility = "hidden";
        document.getElementById(error1).style.visibility = "visible";
        pwd.SetVisible(false);
        pwd1.SetVisible(true);
        pwd1.SetValue(value);
        pwd.SetValue(value);
    }
}


function ChangePassWord1() {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");

    var changepwdctrl = ASPxClientControl.GetControlCollection().GetByName("ChangePwd");
    var existPwdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtexstPwd");
    var newPwdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtNewPwd");
    var confPwdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtCnfNewPwd");
    var newPwdCtrl1 = ASPxClientControl.GetControlCollection().GetByName("txtNewPwd1");
    var confPwdCtrl1 = ASPxClientControl.GetControlCollection().GetByName("txtCnfNewPwd1");
    var extPwd = existPwdCtrl == null ? "" : existPwdCtrl.GetValue();
    var newPwd = "";
    var ConfPwd = "";
    if (newPwdCtrl.GetVisible()) {
        newPwd = newPwdCtrl == null ? "" : newPwdCtrl.GetValue();

    }
    else if (newPwdCtrl1.GetVisible()) {
        newPwd = newPwdCtrl1 == null ? "" : newPwdCtrl1.GetValue();
    }
    if (confPwdCtrl.GetVisible()) {
        ConfPwd = confPwdCtrl == null ? "" : confPwdCtrl.GetValue();

    }
    else if (confPwdCtrl1.GetVisible()) {
        ConfPwd = confPwdCtrl1 == null ? "" : confPwdCtrl1.GetValue();
    }
    extPwd = extPwd == null ? "" : extPwd;
    if (extPwd != "" && newPwd != "" && ConfPwd != "") {
        loadPopup.Show();
        $.ajax({
            type: "post",
            url: "/Employee/ChangePassWord1/",
            data: { 'extPwd': extPwd, 'newPwd': newPwd, 'ConfPwd': ConfPwd },
            success: function (resp) {
                if (resp == "success") {
                    alert("Password changed successfully");
                    loadPopup.Hide();
                    changepwdctrl.Hide();
                }
                else {
                    alert(resp);
                    loadPopup.Hide();
                }
            }

        });
    }

}
function UpdateEmployee(s, e) {
    var EditPop = ASPxClientControl.GetControlCollection().GetByName("CreateEditPop");
    var empID = ASPxClientControl.GetControlCollection().GetByName("editEmpId");
    var frstName = ASPxClientControl.GetControlCollection().GetByName("editEmpFirstName");
    var lstName = ASPxClientControl.GetControlCollection().GetByName("editEmpLastName");
    var dept = ASPxClientControl.GetControlCollection().GetByName("editDepartment");
    var deptCnt = dept != null ? dept.GetItemCount() : 0;
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

    var hasPrevOrder = false;
    var mapUserEmpCtrl = ASPxClientControl.GetControlCollection().GetByName("empMapUsr");
    var emailUsrCtrl = ASPxClientControl.GetControlCollection().GetByName("txtUsrEmail");
    var roleUsrCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbUsrRole");
    var reissueUsrCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbRollout");
    var lstOrddatCtrl = ASPxClientControl.GetControlCollection().GetByName("empUsrLastOrdDate");
    var nextOrddatCtrl = ASPxClientControl.GetControlCollection().GetByName("empUsrNextOrdDate");
    var chkMapAddrCtrl = ASPxClientControl.GetControlCollection().GetByName("chkMapAddr");
    var emailUsr = emailUsrCtrl != null ? emailUsrCtrl.GetValue() : "";
    var chkMapAddr = chkMapAddrCtrl != null ? chkMapAddrCtrl.GetValue() : false;
    var mapUserEmp = mapUserEmpCtrl != null ? mapUserEmpCtrl.GetValue() : false;
    var roleUsr = roleUsrCtrl != null ? roleUsrCtrl.GetValue() : "";
    var reissueUsr = reissueUsrCtrl != null ? reissueUsrCtrl.GetValue() : "";
    var lstOrddat = lstOrddatCtrl != null ? lstOrddatCtrl.GetValue() != null ? lstOrddatCtrl.GetValue().toISOString() : "" : "";
    var nextOrddat = nextOrddatCtrl != null ? nextOrddatCtrl.GetValue() != null ? nextOrddatCtrl.GetValue().toISOString() : "" : "";
    var userActiveCtrl = ASPxClientControl.GetControlCollection().GetByName("UsrActive");
    var userActive = userActiveCtrl != null ? userActiveCtrl.GetValue() : false;
    //lstOrddat = lstOrddat.toISOString();
    var OrderAddrMess = "You have unconfirmed orders would you like to change the address on these orders ? \n\n Click ok to change the address on these orders or cancel to change your delivery address for future orders";
    if (s.name != "UpdateBtn_Template") {
        if ((hoursCmb == undefined || hoursCmb == null) && (hoursDept == undefined || hoursDept == null)) {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & selUcode.lastChangedValue != null) {
                if (deptCnt > 0) {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & selUcode.lastChangedValue.trim() != "") {
                        $.ajax({
                            type: "POST",
                            url: "/Employee/HasPreviousOrders/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (PrevOrder) {
                                if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                    if (confirm(OrderAddrMess)) {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                    else {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                } else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            } else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                            }
                        });


                    }
                }
                else {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & selUcode.lastChangedValue.trim() != "") {
                        $.ajax({
                            type: "POST",
                            url: "/Employee/HasPreviousOrders/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (PrevOrder) {
                                if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                    if (confirm(OrderAddrMess)) {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                } else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                    else {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                } else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            } else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                            }
                        });


                    }
                }
            }
            else {
                alert("Please fill all the mandatory fields");
            }
        }
        else if ((hoursCmb == undefined || hoursCmb == null) || (hoursDept != undefined || hoursDept != null)) {
            var hrsDept = hoursDept.GetValue();
            var hrsNo = hoursNo.GetValue();
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hrsDept != null) {
                if (deptCnt > 0) {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & hrsDept.trim() != "") {
                        $.ajax({
                            type: "POST",
                            url: "/Employee/HasPreviousOrders/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (PrevOrder) {
                                if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                    if (confirm(OrderAddrMess)) {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });

                                    }
                                    else {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });

                                    }
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            }
                                            else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                            }
                        }
                        );

                    }
                }
                else {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & hrsDept.trim() != "") {

                        $.ajax({
                            type: "POST",
                            url: "/Employee/HasPreviousOrders/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (PrevOrder) {
                                if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                    if (confirm(OrderAddrMess)) {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                    else {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            }
                                            else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                            }
                        }
                        );

                    }
                }
            }
            else {
                alert("Please fill all the mandatory fields");
            }
        }
        else {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hoursCmb.lastChangedValue != null) {
                if (deptCnt > 0) {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "" & hoursCmb.lastChangedValue.trim() != "") {
                        $.ajax({
                            type: "POST",
                            url: "/Employee/HasPreviousOrders/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (PrevOrder) {
                                if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                    if (confirm(OrderAddrMess)) {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hrsCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                    else {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hrsCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hrsCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            }
                                            else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                            }
                        });


                    }
                }
                else {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & hoursCmb.lastChangedValue.trim() != "") {
                        $.ajax({
                            type: "POST",
                            url: "/Employee/HasPreviousOrders/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (PrevOrder) {
                                if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                    if (confirm(OrderAddrMess)) {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hrsCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                    else {
                                        var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hrsCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                    alert("Please fill all the mandatory fields");
                                                }
                                                else {
                                                    alert(response);
                                                }
                                            }
                                        });
                                    }
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hrsCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            }
                                            else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                            }
                        });
                    }
                }
            }
            else {
                alert("Please fill all the mandatory fields");
            }
        }
    }
    else {
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null) {
            if (deptCnt > 0) {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & dept.lastSuccessText.trim() != "") {
                    $.ajax({
                        type: "POST",
                        url: "/Employee/HasPreviousOrders/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (PrevOrder) {
                            if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                if (confirm(OrderAddrMess)) {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            } else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            } else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                            }
                            else {
                                var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                            alert("Please fill all the mandatory fields");
                                        } else {
                                            alert(response);
                                        }
                                    }
                                });
                            }
                        }
                    });
                }
            }
            else {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "") {
                    $.ajax({
                        type: "POST",
                        url: "/Employee/HasPreviousOrders/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (PrevOrder) {
                            if (PrevOrder.PrevOrder && PrevOrder.AddressChanged) {
                                if (confirm(OrderAddrMess)) {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'updOrder': true, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            } else {
                                                alert(response);
                                            }
                                        }
                                    });
                                }
                                else {
                                    var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                                alert("Please fill all the mandatory fields");
                                            }
                                        }
                                    });
                                }
                            }
                            else {
                                var data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'isActive': isAct.previousValue, 'Address': addressVal, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'usrActive': userActive };
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
                                            alert("Please fill all the mandatory fields");
                                        } else {
                                            alert(response);
                                        }
                                    }
                                });
                            }
                        }
                    });

                }
            }
        }
        else {
            alert("Please fill all the mandatory fields");
        }
    }

}




function CreateEmployee(s, e) {
    var EditPop = ASPxClientControl.GetControlCollection().GetByName("CreateEditPop");
    var empID = ASPxClientControl.GetControlCollection().GetByName("editEmpId");
    var frstName = ASPxClientControl.GetControlCollection().GetByName("editEmpFirstName");
    var lstName = ASPxClientControl.GetControlCollection().GetByName("editEmpLastName");
    var dept = ASPxClientControl.GetControlCollection().GetByName("editDepartment");
    var deptCnt = dept != null ? dept.GetItemCount() : 0;
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
    var createUsrCtrl = ASPxClientControl.GetControlCollection().GetByName("UserCreationrequest");
    var createUsr = createUsrCtrl != null ? createUsrCtrl.GetValue() : false;
    var mapUserEmpCtrl = ASPxClientControl.GetControlCollection().GetByName("empMapUsr");
    var emailUsrCtrl = ASPxClientControl.GetControlCollection().GetByName("txtUsrEmail");
    var roleUsrCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbUsrRole");
    var reissueUsrCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbRollout");
    var lstOrddatCtrl = ASPxClientControl.GetControlCollection().GetByName("empUsrLastOrdDate");
    var nextOrddatCtrl = ASPxClientControl.GetControlCollection().GetByName("empUsrNextOrdDate");
    var chkMapAddrCtrl = ASPxClientControl.GetControlCollection().GetByName("chkMapAddr");
    var emailUsr = emailUsrCtrl != null ? emailUsrCtrl.GetValue() : "";
    var chkMapAddr = chkMapAddrCtrl != null ? chkMapAddrCtrl.GetValue() : false;
    var mapUserEmp = mapUserEmpCtrl != null ? mapUserEmpCtrl.GetValue() : false;
    var roleUsr = roleUsrCtrl != null ? roleUsrCtrl.GetValue() : "";
    var reissueUsr = reissueUsrCtrl != null ? reissueUsrCtrl.GetValue() : "";
    var isMapped = empMapper == null | empMapper == undefined ? false : empMapper.GetValue();
    var lstOrddat = lstOrddatCtrl != null ? lstOrddatCtrl.GetValue() != null ? lstOrddatCtrl.GetValue().toISOString() : "" : "";
    var nextOrddat = nextOrddatCtrl != null ? nextOrddatCtrl.GetValue() != null ? nextOrddatCtrl.GetValue().toISOString() : "" : "";
    if (s.name != "CreateBtn_Template") {
        if ((hoursCmb == undefined || hoursCmb == null) && (hoursDept == undefined || hoursDept == null)) {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & selUcode.lastChangedValue != null) {
                if (deptCnt > 0) {
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
                                        if (confirm("Do you want to activate the employee?")) {
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };

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
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                        //            alert("Please fill all the mandatory fields");
                        //        }
                        //    }
                        //});


                    }
                }
                else {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & selUcode.lastChangedValue.trim() != "") {

                        var data1;
                        var date = new Date().toISOString();
                        $.ajax({
                            type: "POST",
                            url: "/Employee/EmployeeIdValidation/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (response) {
                                if (response == "Success") {
                                    if (isAct.previousValue == false) {
                                        if (confirm("Do you want to activate the employee?")) {
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                        //            alert("Please fill all the mandatory fields");
                        //        }
                        //    }
                        //});


                    }
                }

            }
            else {
                alert("Please fill all the mandatory fields");
            }
        }
        else if ((hoursCmb == undefined || hoursCmb == null) && (hoursDept != undefined || hoursDept != null)) {
            var hrsDept = hoursDept.GetValue();
            var hrsNo = hoursNo.GetValue();
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hoursDept.lastChangedValue != null & hrsDept != null) {
                if (deptCnt > 0) {
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
                                        if (confirm("Do you want to activate the employee?")) {
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & hrsDept != "") {

                        var data1;
                        var date = new Date().toISOString();
                        $.ajax({
                            type: "POST",
                            url: "/Employee/EmployeeIdValidation/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (response) {
                                if (response == "Success") {
                                    if (isAct.previousValue == false) {
                                        if (confirm("Do you want to activate the employee?")) {
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursDept': hrsDept.trim(), 'hoursNo': hrsNo.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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

            }
            else {
                alert("Please fill all the mandatory fields");
            }
        }
        else {
            if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null & hoursCmb.lastChangedValue != null) {
                if (deptCnt > 0) {
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
                                        if (confirm("Do you want to activate the employee?")) {
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                        //            alert("Please fill all the mandatory fields");
                        //        }
                        //    }
                        //});


                    }
                }
                else {
                    if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "" & hoursCmb.lastChangedValue.trim() != "") {

                        var data1;
                        var date = new Date().toISOString();
                        $.ajax({
                            type: "POST",
                            url: "/Employee/EmployeeIdValidation/",
                            data: { 'empId': empID.lastChangedValue.trim() },
                            success: function (response) {
                                if (response == "Success") {
                                    if (isAct.previousValue == false) {
                                        if (confirm("Do you want to activate the employee?")) {
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                            data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'hoursCmb': hoursCmb.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                        //            alert("Please fill all the mandatory fields");
                        //        }
                        //    }
                        //});


                    }
                }

            }
            else {
                alert("Please fill all the mandatory fields");
            }
        }
    }
    else {
        if (empID.lastChangedValue != null & frstName.lastChangedValue != null & lstName.lastChangedValue != null & dept.lastSuccessText != null) {
            if (deptCnt > 0) {
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
                                    if (confirm("Do you want to activate the employee?")) {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                    data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                    //            alert("Please fill all the mandatory fields");
                    //        }
                    //    }
                    //});

                }
            }
            else {
                if (empID.lastChangedValue.trim() != "" & frstName.lastChangedValue.trim() != "" & lstName.lastChangedValue.trim() != "") {
                    var data1;
                    var date = new Date();
                    $.ajax({
                        type: "POST",
                        url: "/Employee/EmployeeIdValidation/",
                        data: { 'empId': empID.lastChangedValue.trim() },
                        success: function (response) {
                            if (response == "Success") {
                                if (isAct.previousValue == false) {
                                    if (confirm("Do you want to activate the employee?")) {
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                        data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': isAct.previousValue, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                                    data1 = { 'StartDate': strtDate != undefined ? strtDate.date.toJSON() : date, 'EndDate': endDate != undefined ? endDate.date.toJSON() : date, 'EmpFirstName': frstName.lastChangedValue.trim(), 'EmpLastName': lstName.lastChangedValue.trim(), 'EmployeeId': empID.lastChangedValue.trim(), 'EmpUcodes': selUcode.lastChangedValue.trim(), 'Department': dept.lastSuccessText.trim(), 'Address': address != null && address != undefined ? address.lastSuccessText.trim() : "", 'isActive': true, 'isMapped': isMapped, 'createUsr': createUsr, 'emailUsr': emailUsr, 'mapUserEmp': mapUserEmp, 'roleUsr': roleUsr, 'reissueUsr': reissueUsr, 'chkMapAddr': chkMapAddr, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat, 'lstOrddat': lstOrddat, 'nextOrddat': nextOrddat };
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
                    //            alert("Please fill all the mandatory fields");
                    //        }
                    //    }
                    //});

                }
            }

        }
        else {
            alert("Please fill all the mandatory fields");
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
                    if (!response.indexOf("Login") > -1) {
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
    //$('.qtyplus_pts').click(function (e) {
    //    fieldName = $(this).attr('field');
    //    var valuee = document.getElementsByName(fieldName);
    //    $.ajax({
    //        type: "post",
    //        url: "",
    //        data:,
    //        success:function(response)
    //        {

    //        }
    //    });
    //});
    //$(".qtyminus_pts").click(function (e) {
    //    fieldName = $(this).attr('field');
    //    var valuee = document.getElementsByName(fieldName);
    //    $.ajax({
    //        type: "post",
    //        url: "",
    //        data:,
    //        success:function(response)
    //        {

    //        }
    //    });
    //});
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
    var searchBtn = document.getElementById("EmpSearch");
    searchBtn.outerHTML = "<button class='openbtn btn' id='EmpSearch' onclick='closeNav();'><span class='glyphicon glyphicon-search'></span> Employee search </button>";
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    var searchBtn = document.getElementById("EmpSearch");
    searchBtn.outerHTML = "<button class='openbtn btn' id='EmpSearch' onclick='openNav();'><span class='glyphicon glyphicon-search'></span> Employee search </button>";
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
                    loadPopup.Hide();
                    var EmployeeGrid = document.getElementById("EmployeeGridViewPartial");
                    EmployeeGrid.innerHTML = response;
                    MVCxClientUtils.FinalizeCallback();
                    setCollapsed();
                    checkEmpEmail();
                    EmergencyMessagePop();
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
            if (response != "" && !response.indexOf("Login") > -1) {
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
                loadPopup.Hide();
                var EmployeeGrid = document.getElementById("EmployeeGridViewPartial");
                EmployeeGrid.innerHTML = response;
                MVCxClientUtils.FinalizeCallback();
                setCollapsed();
                checkEmpEmail();
                // EmergencyMessagePop();
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

function ChangePassword() {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var changepwdctrl = ASPxClientControl.GetControlCollection().GetByName("ChangePwd");
    $.ajax({
        url: "/Employee/ChangePassword/",
        type: "post",
        success: function (response) {
            if (response != null && response != "") {
                var pwdDiv = document.getElementById("ChangePwdDiv");
                pwdDiv.innerHTML = response;
                loadPopup.Hide();
                changepwdctrl.Show();
                MVCxClientUtils.FinalizeCallback();
            }
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
    var AcceptBtnctrl = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var cnf = s.name.indexOf("cnf") > -1 ? true : false;
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var addDescription = ASPxClientControl.GetControlCollection().GetByName("CmbAddress");
    var addDesc = addDescription != null ? addDescription.GetValue() : "";
    var ref = ASPxClientControl.GetControlCollection().GetByName("txtCustRef");
    var custRef = ref.GetValue(); var commentBox = ASPxClientControl.GetControlCollection().GetByName("txtCommentsExternal");
    comment = commentBox != null ? commentBox.GetValue() : "";


    //var win = document.referrer;
    // alert(win);
    //$.ajax({
    //    url: "Basket/GetCarriageStatus",
    //    type: "POST",
    //    success: function (result) {
    //        if (result) {
    if (addDesc != null && addDesc != "") {
        AcceptBtnctrl.SetEnabled(false);
        $.ajax({
            url: "/Home/GetBasketStatus/",
            type: "post",
            success: function (response) {
                if (response == "") {

                    $.ajax({
                        url: "/Home/GetOrderEnforcementStatus/",
                        type: "post",
                        success: function (response) {
                            if (response == "") {

                                $.ajax({
                                    url: "/Basket/AcceptOrder/",
                                    type: "POST",
                                    data: { 'addDesc': addDesc, 'CNF': cnf },
                                    success: function (resp) {
                                        if (resp.type != "" && resp.type != null) {
                                            if (resp.type.indexOf("Carrier") > -1) {
                                                alert(resp.type);
                                                AcceptBtnctrl.SetEnabled(true);
                                            } else if (resp.type.indexOf("{%FREESTOCKERROR%}") > -1) {
                                                var rnse = "";
                                                rnse = resp.type.replace("{%FREESTOCKERROR%}", "The Freestock has changed whilst you have been placing the order \n\n");
                                                alert(rnse);
                                                AcceptBtnctrl.SetEnabled(true);
                                                window.location.reload();
                                            }
                                            else {
                                                alert(resp.type);
                                                AcceptBtnctrl.SetEnabled(true);
                                            }

                                            loadPopup.Hide();
                                        }
                                        else {
                                            var message = "";
                                            if (resp.results.length > 0) {
                                                for (var k = 0; k < resp.results.length; k++) {
                                                    if (resp.results[k].isedit) {
                                                        message = message + "Your uniform order has been updated successfully,order reference:" + resp.results[k].OrderNo + " (" + resp.results[k].EmployeeId + ")." + resp.results[k].OrderConfirmation + ". \n";
                                                    }
                                                    else {
                                                        message = message + "Your uniform order has been successfully placed,order reference:" + resp.results[k].OrderNo + " (" + resp.results[k].EmployeeId + ")." + resp.results[k].OrderConfirmation + ". \n";
                                                    }
                                                }
                                                if (resp.results[0].OrderConfirmationPop != "" && resp.results[0].OrderConfirmationPop != null && resp.results[0].OrderConfirmationPop != undefined) {
                                                    message = message + " \n\n\n Do you want to print confirmation? \n (Click ok to print,Cancel to not print)";
                                                    if (confirm(message)) {
                                                        var orderConfirmationPopup = ASPxClientControl.GetControlCollection().GetByName("orderConfirmation");
                                                        loadPopup.Hide()
                                                        var ordConfim = document.getElementById("ordeConfirm");
                                                        ordConfim.innerHTML = "";
                                                        ordConfim.innerHTML = resp.results[0].OrderConfirmationPop;
                                                        orderConfirmationPopup.Show();
                                                    }
                                                    else {
                                                        loadPopup.Hide();
                                                        ////window.history.back();
                                                        if (document.referrer.indexOf("Home") > -1) {
                                                            window.location = "/Employee/Index/";
                                                        }
                                                        else {
                                                            window.location = document.referrer;
                                                        }
                                                    }
                                                    AcceptBtnctrl.SetEnabled(true);
                                                }
                                                else {
                                                    alert(message);
                                                    loadPopup.Hide();
                                                    ////window.history.back();
                                                    if (document.referrer.indexOf("Home") > -1) {
                                                        window.location = "/Employee/Index/";
                                                    }
                                                    else {
                                                        window.location = document.referrer;
                                                    }
                                                    AcceptBtnctrl.SetEnabled(true);
                                                }
                                            }
                                            else {
                                                loadPopup.Hide();
                                                AcceptBtnctrl.SetEnabled(true);
                                            }

                                        }
                                    }
                                });
                            }
                            else {
                                alert(response);
                                loadPopup.Hide()

                                AcceptBtnctrl.SetEnabled(true);
                            }
                        }
                    });

                }
                else {
                    if (response == "fail") {
                        alert("There are no items in the cart please continue shopping.");
                        window.location = "/Home/Index/"
                    }
                    else if (response.indexOf("{%FREESTOCKERROR%}") > -1) {
                        response = response.replace("{%FREESTOCKERROR%}", "The Freestock has changed whilst you have been placing the order \n\n");
                        alert(response);
                        loadPopup.Hide();
                        AcceptBtnctrl.SetEnabled(true);
                        window.location.reload();
                    }
                    else {
                        response = response.replace("///", "");
                        if (confirm(response)) {
                            $.ajax({
                                url: "/Home/GetOrderEnforcementStatus/",
                                type: "post",
                                success: function (response) {
                                    if (response == "") {

                                        $.ajax({
                                            url: "/Basket/AcceptOrder/",
                                            type: "POST",
                                            data: { 'addDesc': addDesc, 'CNF': cnf },
                                            success: function (resp) {
                                                if (resp.type != "" && resp.type != null) {
                                                    if (resp.type.indexOf("Carrier") > -1) {
                                                        alert(resp.type);
                                                        AcceptBtnctrl.SetEnabled(true);
                                                    }
                                                    else if (resp.type.indexOf("{%FREESTOCKERROR%}") > -1) {
                                                        var rnse = "";
                                                        rnse = resp.type.replace("{%FREESTOCKERROR%}", "The Freestock has changed whilst you have been placing the order \n\n");
                                                        alert(rnse);
                                                        AcceptBtnctrl.SetEnabled(true);
                                                        window.location.reload();
                                                    }
                                                    else {
                                                        alert(resp.type);
                                                        AcceptBtnctrl.SetEnabled(true);
                                                    }
                                                    loadPopup.Hide();
                                                }
                                                else {
                                                    var message = "";
                                                    if (resp.results.length > 0) {
                                                        for (var k = 0; k < resp.results.length; k++) {
                                                            if (resp.results[k].isedit) {
                                                                message = message + "Your uniform order has been updated successfully,order reference:" + resp.results[k].OrderNo + " (" + resp.results[k].EmployeeId + ")." + resp.results[k].OrderConfirmation + ". \n";
                                                            }
                                                            else {
                                                                message = message + "Your uniform order has been successfully placed,order reference:" + resp.results[k].OrderNo + " (" + resp.results[k].EmployeeId + ")." + resp.results[k].OrderConfirmation + ". \n";
                                                            }
                                                        }
                                                        if (resp.results[0].OrderConfirmationPop != "" && resp.results[0].OrderConfirmationPop != null && resp.results[0].OrderConfirmationPop != undefined) {
                                                            message = message + " \n\n\n Do you want to print confirmation? \n (Click ok to print,Cancel to not print)";
                                                            if (confirm(message)) {
                                                                var orderConfirmationPopup = ASPxClientControl.GetControlCollection().GetByName("orderConfirmation");
                                                                loadPopup.Hide()
                                                                var ordConfim = document.getElementById("ordeConfirm");
                                                                ordConfim.innerHTML = "";
                                                                ordConfim.innerHTML = resp.results[0].OrderConfirmationPop;
                                                                orderConfirmationPopup.Show();
                                                                AcceptBtnctrl.SetEnabled(true);
                                                            }
                                                            else {
                                                                AcceptBtnctrl.SetEnabled(true);
                                                                loadPopup.Hide();
                                                                //window.history.back();
                                                                if (document.referrer.indexOf("Home") > -1) {
                                                                    window.location = "/Employee/Index/";
                                                                }
                                                                else {
                                                                    window.location = document.referrer;
                                                                }
                                                            }

                                                        }
                                                        else {
                                                            AcceptBtnctrl.SetEnabled(true);
                                                            alert(message);
                                                            loadPopup.Hide();
                                                            //window.history.back();
                                                            if (document.referrer.indexOf("Home") > -1) {
                                                                window.location = "/Employee/Index/";
                                                            }
                                                            else {
                                                                window.location = document.referrer;
                                                            }
                                                        }
                                                    }
                                                    else {
                                                        AcceptBtnctrl.SetEnabled(true);
                                                        loadPopup.Hide();
                                                    }

                                                }
                                            }
                                        });
                                    }
                                    else {
                                        alert(response);
                                        loadPopup.Hide();
                                        AcceptBtnctrl.SetEnabled(true);
                                    }
                                }
                            });

                        }
                        else {
                            loadPopup.Hide();
                            AcceptBtnctrl.SetEnabled(true);
                        }
                    }
                }
            }
        });

    }
    else {
        alert("Please fill address and customer reference");
        loadPopup.Hide();
        AcceptBtnctrl.SetEnabled(true);
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
    var CarriageStyleCmbbox = ASPxClientControl.GetControlCollection().GetByName("CarriageStyleCmbbox");
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
            if (commentBox != null) {
                commentBox.SetValue(resp.CommentExternal);
            } if (txtTotGoods != null) {
                txtTotGoods.SetValue(resp.ordeTotal);
            } if (txtCarrierCharges != null) {
                txtCarrierCharges.SetValue(resp.carriage);
            } if (txtOrdTotal != null) {
                txtOrdTotal.SetValue(resp.Total);
            } if (txtVAT != null) {
                txtVAT.innerHTML = resp.VatPercent;
            } if (txtGrndTot != null) {
                txtGrndTot.SetValue(resp.GrossTotal);
            } if (CarriageStyleCmbbox != null) {
                CarriageStyleCmbbox.SetSelectedIndex(-1);
            } if (nomCode1 != null) {
                nomCode1.SetValue(resp.nomCode1);
            } if (nomCode2 != null) {
                nomCode2.SetValue(resp.nomCode2);
            } if (nomCode3 != null) {
                nomCode3.SetValue(resp.nomCode3);
            } if (nomCode4 != null) {
                nomCode4.SetValue(resp.nomCode4);
            }
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
                    if (resp.indexOf("HEADERVALUENOTZERO") > -1) {
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
    var styleId_Val = style.indexOf(",") > -1 ? GetStyleIdSwatch(style, orgStyle) : style;
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
            if (ssss.indexOf('£') > -1) {
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

    if (stylearr[1].indexOf(',') > -1) {
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
            if (ssss.indexOf('£') > -1) {
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

    if (stylearr[1].indexOf(',') > -1) {
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
            if (ssss.indexOf('£') > -1) {
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

    if (stylearr[1].indexOf(',') > -1) {
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
            data: { 'EmployeeId': "", 'EmpName': "", 'Ucodes1': ucode },
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


$('#qty_textbox').change(function () {
    alert("hi");
});



function setCollapsed() {
    var lookups = ASPxClientControl.GetControlCollection().GetByName("empFilter");
    lookups.SetCollapsed(true);
    $("#wrapper").toggleClass("active");
}
function setCollapsedOrderFilter() {
    var lookups = ASPxClientControl.GetControlCollection().GetByName("OrderFilter");
    lookups.SetCollapsed(true);
    $("#wrapper").toggleClass("active");
}
function Adjustment(s, e) {
    if (s.cpErrorString != null) {
        alert(s.cpErrorString);
    }
    var adjustment = document.getElementById("adjustmentPts");
    if (adjustment != null) {
        adjustment.innerText = s.cpErrorString;
    }
    PointsEndCallBack();
}

function CarriageStyleCmbboxchange(s, e) {
    var carrierStylecmb = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var selStyle = carrierStylecmb.GetValue();
    var URL = s.name.indexOf("Rtn") > -1 ? "/Return/InsertCarriageLine/" : "/Basket/InsertCarriageLine/";
    if (selStyle != null && selStyle != "") {
        $.ajax({
            url: URL,
            type: "POST",
            data: { 'carrStyle': selStyle },
            success: function (response) {
                if (response != "") {
                    window.location.reload();
                }
                else {
                    alert("The carriage style already exists in the cart");
                }
            }
        });
    }

}

function Expand(s, e) {
    grid = ASPxClientControl.GetControlCollection().GetByName(s.name);
    grid.ExpandAllDetailRows();
}

function OrderEdit(orderNo, empId) {
    $.ajax({
        url: "/OrderDisplay/SetEmployee/",
        type: "post",
        data: { 'empId': empId },
        success: function (resp) {
            if (resp.toLowerCase().indexOf("emp") > -1 == false) {
                window.location = "/Basket/ShowBasket?ordeNo=" + orderNo;
            }
            else {
                alert(resp);
            }
        }
    });

}

function GetallOrders(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");

    var controlName = s.name;
    var emergencyOrderCtrl = ASPxClientControl.GetControlCollection().GetByName("chkEmergencyOrders");
    var Empidsear = ASPxClientControl.GetControlCollection().GetByName("Empidsear");
    var Empid = Empidsear == null ? "" : Empidsear.GetValue();
    var Empnamesear = ASPxClientControl.GetControlCollection().GetByName("Empnamesear");
    var StrtDatesear = ASPxClientControl.GetControlCollection().GetByName("StrtDatesear");
    var Empname = Empnamesear == null ? "" : Empnamesear.GetValue(); var StrtDate = StrtDatesear == null ? "" : StrtDatesear.GetValue();
    var frmOrderno = ASPxClientControl.GetControlCollection().GetByName("FromOrderNo");
    var frmOno = frmOrderno == null ? 0 : frmOrderno.GetValue();
    var toOrderno = ASPxClientControl.GetControlCollection().GetByName("ToOrderNo");
    var toOno = toOrderno == null ? 0 : toOrderno.GetValue();
    var frmOrderDate = ASPxClientControl.GetControlCollection().GetByName("FromOrderdate");
    var frmODate = frmOrderDate.GetValue();
    var toOrderDate = ASPxClientControl.GetControlCollection().GetByName("ToOrderdate");
    var toODate = toOrderDate.GetValue();
    var custRef = ASPxClientControl.GetControlCollection().GetByName("CustomerOrderno");
    var cref = custRef != null ? custRef.GetValue() : "";
    var ordStat = ASPxClientControl.GetControlCollection().GetByName("Orderstatus");
    var orsTat = ordStat != null ? ordStat.GetValue() : "";
    var emergencyOrder = emergencyOrderCtrl != null ? emergencyOrderCtrl.GetValue() == true ? 1 : 0 : 0;

    //var noOfrecs = ASPxClientControl.GetControlCollection().GetByName("recstodisplay");
    //var noOfrec = noOfrecs.GetValue();
    var usr = ASPxClientControl.GetControlCollection().GetByName("User");
    var usrVal = usr != null ? usr.GetValue() : "";
    if (controlName != null && controlName != "") {
        if ((frmOno == null | frmOno == "") && (toOno == null | toOno == "") && (frmODate == null | frmODate == "") && (toODate == null | toODate == "") && (cref == null | cref == "") && (orsTat == null | orsTat == "") && (usrVal == null | usrVal == "")) {
        }
        else if (controlName == "btnordno") {

            if (frmOno != null | toOno != null) {

                loadPopup.Show();
                $.ajax({
                    url: "/OrderDisplay/ShowOrderGridViewPartial/",
                    type: "post",
                    //data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': false, 'exact': false },
                    data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno },
                    success: function (response) {
                        if (response != null && response != "") {
                            var gridDiv = document.getElementById("ShowOrders");
                            gridDiv.innerHTML = "";
                            gridDiv.innerHTML = response;
                            loadPopup.Hide();
                        }
                    }

                });
            }
        }
        else if (controlName == "chkEmergencyOrders") {
            loadPopup.Show();
            $.ajax({
                url: "/OrderDisplay/ShowOrderGridViewPartial/",
                type: "post",
                data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': false, 'exact': false },
                success: function (response) {
                    if (response != null && response != "") {
                        var gridDiv = document.getElementById("ShowOrders");
                        gridDiv.innerHTML = "";
                        gridDiv.innerHTML = response;
                        loadPopup.Hide();
                    }
                }

            });

        }
        else if (controlName == "btnorddate") {

            if (frmODate != null || toODate != null) {
                loadPopup.Show();
                $.ajax({
                    url: "/OrderDisplay/ShowOrderGridViewPartial/",
                    type: "post",
                    //data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': false, 'exact': false },
                    data: { 'emergency': emergencyOrder, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON() },
                    success: function (response) {
                        if (response != null && response != "") {
                            var gridDiv = document.getElementById("ShowOrders");
                            gridDiv.innerHTML = "";
                            gridDiv.innerHTML = response;
                            loadPopup.Hide();
                        }
                    }
                });
            }
        }
        else if (controlName == "btnsearch") {
            if ((Empid != null && Empid != "") || (Empname != null && Empname != "") || (StrtDate != null)) {
                loadPopup.Show();
                $.ajax({
                    url: "/OrderDisplay/ShowOrderGridViewPartial/",
                    type: "post",
                    //data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': false, 'exact': false, 'Empid': Empid, 'Empname': Empname, 'StrtDate': StrtDate != null ? StrtDate.toJSON() : null },
                    data: { 'emergency': emergencyOrder, 'users': usrVal, 'Empid': Empid, 'Empname': Empname, 'StrtDate': StrtDate != null ? StrtDate.toJSON() : null },
                    success: function (response) {
                        if (response != null && response != "") {
                            var gridDiv = document.getElementById("ShowOrders");
                            gridDiv.innerHTML = "";
                            gridDiv.innerHTML = response;
                            loadPopup.Hide();
                        }
                    }
                });

            }
        }
        else if (controlName == "btnShwlike") {

            if (cref != null && cref != "") {
                loadPopup.Show();
                $.ajax({
                    url: "/OrderDisplay/ShowOrderGridViewPartial/",
                    type: "post",
                    //data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': true, 'exact': false },
                    data: { 'emergency': emergencyOrder, 'custRef': cref, 'like': true, 'exact': false },
                    success: function (response) {
                        if (response != null && response != "") {
                            var gridDiv = document.getElementById("ShowOrders");
                            gridDiv.innerHTML = "";
                            gridDiv.innerHTML = response;
                            loadPopup.Hide();
                        }
                    }
                });
            }
        }
        else if (controlName == "btnShwexac") {

            if (cref != null && cref != "") {
                loadPopup.Show();
                $.ajax({
                    url: "/OrderDisplay/ShowOrderGridViewPartial/",
                    type: "post",
                    //data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': false, 'exact': true },
                    data: { 'emergency': emergencyOrder, 'custRef': cref, 'like': false, 'exact': true },
                    success: function (response) {
                        if (response != null && response != "") {
                            var gridDiv = document.getElementById("ShowOrders");
                            gridDiv.innerHTML = "";
                            gridDiv.innerHTML = response;
                            loadPopup.Hide();
                        }
                    }
                });
            }
        }
        else if (controlName == "Orderstatus") {

            if (orsTat != null && orsTat != "") {
                loadPopup.Show();
                $.ajax({
                    url: "/OrderDisplay/ShowOrderGridViewPartial/",
                    type: "post",
                    //data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': false, 'exact': false },
                    data: { 'emergency': emergencyOrder, 'ordStatus': orsTat },
                    success: function (response) {
                        if (response != null && response != "") {
                            var gridDiv = document.getElementById("ShowOrders");
                            gridDiv.innerHTML = "";
                            gridDiv.innerHTML = response;
                            loadPopup.Hide();
                        }
                    }
                });
            }
        }
        else if (controlName == "User") {

            if (usrVal != null && usrVal != "") {
                loadPopup.Show();
                $.ajax({
                    url: "/OrderDisplay/ShowOrderGridViewPartial/",
                    type: "post",
                    //data: { 'emergency': emergencyOrder, 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'like': false, 'exact': false },
                    data: { 'emergency': emergencyOrder, 'users': usrVal },
                    success: function (response) {
                        if (response != null && response != "") {
                            var gridDiv = document.getElementById("ShowOrders");
                            gridDiv.innerHTML = "";
                            gridDiv.innerHTML = response;
                            loadPopup.Hide();
                        }
                    }
                });
            }
        }
        else if (controlName == "recstodisplay") {

            //if (noOfrec != null && noOfrec != "") {
            //    loadPopup.Show();
            //    $.ajax({
            //        url: "/OrderDisplay/ShowOrderGridViewPartial/",
            //        type: "post",
            //        data: { 'frmOrderno': frmOno, 'toOrderNo': toOno, 'frmOrderdate': frmODate.toJSON(), 'toOrderDate': toODate.toJSON(), 'custRef': cref, 'ordStatus': orsTat, 'users': usrVal, 'recsToDisplay': noOfrec, 'like': false, 'exact': false },
            //        success: function (response) {
            //            if (response != null && response != "") {
            //                var gridDiv = document.getElementById("ShowOrders");
            //                gridDiv.innerHTML = "";
            //                gridDiv.innerHTML = response;
            //                loadPopup.Hide();
            //            }
            //        }
            //    });
            //}
        }
        else if (controlName == "resetBtn") {
            loadPopup.Show();
            $.ajax({
                url: "/OrderDisplay/ShowOrderGridViewPartial/",
                type: "post",
                success: function (response) {
                    if (response != null && response != "") {
                        if (Empidsear != null) {
                            Empidsear.SetValue("");
                        }
                        if (Empnamesear != null) {
                            Empnamesear.SetValue("");
                        }
                        if (frmOrderno != null) {
                            frmOrderno.SetValue("");
                        }
                        if (toOrderno != null) {
                            toOrderno.SetValue("");
                        }

                        if (custRef != null) {
                            custRef.SetValue("");
                        }
                        if (emergencyOrderCtrl != null) {
                            emergencyOrderCtrl.SetValue(false);
                        }
                        var gridDiv = document.getElementById("ShowOrders");
                        gridDiv.innerHTML = "";
                        gridDiv.innerHTML = response;
                        loadPopup.Hide();
                    }
                }
            });
        }
    }
}

function ShowDetailOrder(s, e) {
    var grid = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var ordno = grid.GetRowKey(e.visibleIndex);
    var pop = ASPxClientControl.GetControlCollection().GetByName("OrderDetailPop");
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    if (ordno > 0) {
        $.ajax({
            url: "/OrderDisplay/OrderDetailGridViewPartial/",
            type: "post",
            data: { 'ordno': ordno },
            success: function (response) {
                if (response != null && response != "") {
                    $.ajax({
                        url: "/OrderDisplay/OrderDetailGridView1Partial/",
                        type: "post",
                        data: { 'ordno': ordno },
                        success: function (response1) {
                            if (response1 != null && response1 != "") {
                                var head = document.getElementById("OrderHead");
                                var detail = document.getElementById("OrderDetail");
                                head.innerHTML = "";
                                detail.innerHTML = "";
                                head.innerHTML = response;
                                detail.innerHTML = response1;
                                loadPopup.Hide();
                                pop.SetHeaderText("Order details of  order number: " + ordno);
                                pop.Show();
                            }
                        }

                    });
                }
            }

        });
    }
}

function checkEmpEmail() {
    $.ajax({
        type: "POST",
        url: "/Home/CheckEmpEmail",
        success: function (response) {
            if (response != "" && response != null) {
                var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
                loadPopup.Hide();
                var pop = ASPxClientControl.GetControlCollection().GetByName("EmailPrompt");
                var content = document.getElementById("EmailPromptContent");
                content.innerHTML = "";
                content.innerHTML = response;
                pop.Show();
                MVCxClientUtils.FinalizeCallback();
            }
        },
        error: function () {

        }
    });
}

function EmergencyMessagePop() {
    $.ajax({
        type: "POST",
        url: "/Employee/EmergencyMessagePop",
        success: function (response) {
            if (response != "" && response != null) {
                var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
                loadPopup.Hide();
                var pop = ASPxClientControl.GetControlCollection().GetByName("EmergencyMessage");
                var content = document.getElementById("EmergencyMessageContent");
                content.innerHTML = "";
                content.innerHTML = response;
                pop.Show();
                MVCxClientUtils.FinalizeCallback();
            }
        },
        error: function () {

        }
    });
}

function GetRolloutCheck() {
    $.ajax({
        type: "POST",
        url: "/Home/GetRolloutCheck",
        success: function (response) {
            if (response != null && response != "") {
                var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
                loadPopup.Hide();
                var pop = ASPxClientControl.GetControlCollection().GetByName("RolloutPrompt");
                var content = document.getElementById("RolloutPromptContent");
                content.innerHTML = "";
                content.innerHTML = response;
                pop.Show();
                MVCxClientUtils.FinalizeCallback();
            }
        },
        error: function () {

        }
    });
}
function PROCEEDFURTHERROLLOUT() {
    var pop = ASPxClientControl.GetControlCollection().GetByName("RolloutPrompt");
    $.ajax({
        url: "/Home/SetRolloutTrue/",
        type: "Post",
        success: function (response) {

        }
    });
    pop.Hide();
}

function SaveEmailData(s, e) {
    var emailValidation = document.getElementById("ValidEMail");
    var Email = ASPxClientControl.GetControlCollection().GetByName("emailAlerttxtBox");
    var emailValue = Email != null ? Email.GetValue() : "";
    emailValidation.style.visibility = "hidden";
    if (validateEmail(emailValue)) {

        if (emailValue != "" && emailValue != null) {
            $.ajax({
                type: "post",
                url: "/Home/SaveEmailData/",
                data: { 'email': emailValue },
                success: function (resp) {
                    if (resp == "") {
                        var pop = ASPxClientControl.GetControlCollection().GetByName("EmailPrompt");
                        pop.Hide();
                    }
                }
            });
        }
    }
    else {

        emailValidation.style.visibility = "visible";
    }

}
function validateEmail(emailValue) {

    var pattern = /^[a-zA-Z0-9\-_]+(\.[a-zA-Z0-9\-_]+)*@[a-zA-Z0-9]+(\-[a-zA-Z0-9]+)*(\.[a-zA-Z0-9]+(\-[a-zA-Z0-9]+)*)*\.[a-zA-Z]{2,4}$/;
    if (pattern.test(emailValue)) {
        return true;
    } else {
        return false;
    }
}
function logoff() {
    window.location = "/OrderDisplay/ShowOrders/";
}
function gotoindex() {
    window.location = "/Employee/Index/";
}

function CheckConditions() {
    checkEmpEmail();
    GetRolloutCheck();
    EmergencyMessagePop();
}
function SaveEmpGrid(chart) {
    if (chart == "EmployeeGridView") {
        window.open('/Employee/exporter/', '_blank');
    }
    else if (chart == "ShowOrderGridView") {
        window.open('/OrderDisplay/exporter/', '_blank');
    }
    else if (chart == "ShowRolloutReport") {
        window.open('/Report/exporter/', '_blank');
    }
}



function print(divName) {
    var winPrint = window.open('', '', 'left=0,top=0,width=800,height=600,toolbar=0,scrollbars=0,status=0');
    var printContents = document.getElementById(divName).innerHTML;
    winPrint.document.write(printContents);
    winPrint.document.close();
    winPrint.focus();
    winPrint.print();
    // winPrint.close();

    //var originalContents = document.body.innerHTML;

    //document.body.innerHTML = printContents;

    //window.print();

    //document.body.innerHTML = originalContents;
}


//function OnConfirmGridCheckbox(s, e) {
//    var ordersGrid = ASPxClientControl.GetControlCollection().GetByName("ShowOrderGridView");
//    var chkBox = ASPxClientControl.GetControlCollection().GetByName(s.name);
//    if (chkBox != undefined && chkBox != null) {
//        var ordeNo = s.name.split('cb_');
//        if (chkBox.GetValue()) {
//            SelectedOrdersArr.push(ordeNo[1]);
//        }
//        else if (SelectedOrdersArr.indexOf(ordeNo[1])) {
//            SelectedOrdersArr.pop(ordeNo[1]);
//        }
//    }
//}

//function SelectAllordersOnGrid(s,e)
//{
//    var ordersGrid = ASPxClientControl.GetControlCollection().GetByName("ShowOrderGridView");
//    ordersGrid.SelectAll();
//    var result = ordersGrid.GetVisibleRowsOnPage();
//}

function ConfirmOrders() {
    var ordersGrid = ASPxClientControl.GetControlCollection().GetByName("ShowOrderGridView");
    var index = ordersGrid.GetFocusedRowIndex();
    ordersGrid.GetSelectedFieldValues('OrderNo;PersonPackNo', OnGetSelectedFieldValuess);
    //alert(index);
}
function OnGetSelectedFieldValuess(selectedValues) {

    var selArr = [];
    var Grid = ASPxClientControl.GetControlCollection().GetByName("ShowOrderGridView");
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var indexs = -1;
    loadPopup.Show();
    if (selectedValues != null && selectedValues != "") {
        for (var i = 0; i < selectedValues.length; i++) {
            for (var j = 0; j < selectedValues.length; j++) {
                if (selectedValues[i][0] == Grid.cpIndices[j]) {
                    indexs = selectedValues[i][0];
                }
            }
            if (selectedValues[i][0] != indexs) {
                var obj = { 'ManPackNo': selectedValues[i][1], 'SalesOrderNo': selectedValues[i][0] };
                selArr.push(obj);

            }
        }
        if (selArr.length > 0) {
            $.ajax({
                url: "/OrderDisplay/ConfrimOrders/",
                type: "post",
                data: { 'orderLst': selArr },
                success: function (response) {
                    if (response == "") {
                        alert("Confirmed succssfully");
                        loadPopup.Hide();
                        window.location.reload();
                    }
                }
            });
        }
        else {
            loadPopup.Hide();
            alert("Please select atleast one order to continue");
        }
    }
}

function ShowConfirmOrdersPopup() {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var frmOrdNoControl = ASPxClientControl.GetControlCollection().GetByName("FromOrderNo");
    var toOrdNoControl = ASPxClientControl.GetControlCollection().GetByName("ToOrderNo");
    var frmOrdno = frmOrdNoControl.GetValue();
    var toOrdno = toOrdNoControl.GetValue();
    if (frmOrdno != null && frmOrdno != "" && toOrdno != null && toOrdno != "") {
        $.ajax({
            url: "/OrderDisplay/GetPrintTemplates/",
            type: "post",
            data: { 'frmOrdno': frmOrdno, 'toOrdno': toOrdno },
            success: function (response) {
                var orderConfirmationPopup = ASPxClientControl.GetControlCollection().GetByName("PrintOrderConfirmation");
                if (response != null) {
                    loadPopup.Hide();
                    var ordConfim = document.getElementById("ordeConfirm1");
                    ordConfim.innerHTML = "";
                    ordConfim.innerHTML = response;
                    orderConfirmationPopup.Show();
                }
            }
        });
    }
}

function FilterPrint(s, e) {
    var empId = "";
    var empName = "";
    var ucode = "";
    var ucodeDesc = "";
    var ucodeAdd = "";
    var startDate = "";
    var frstordno = "";
    var lstordno = "";
    var frstOdate = "";
    var lastOdate = "";
    if (s.name == "btnByOrderDate") {
        var firstOrderDate = ASPxClientControl.GetControlCollection().GetByName("FrstOrderDate");
        var lasttOrderDate = ASPxClientControl.GetControlCollection().GetByName("LastOrderDate");
        frstOdate = firstOrderDate.GetValue();
        lastOdate = lasttOrderDate.GetValue();
    } else if (s.name == "btnByorderNO") {
        var firstOrderNO = ASPxClientControl.GetControlCollection().GetByName("FrstOrderNo");
        var lasttOrderDate = ASPxClientControl.GetControlCollection().GetByName("LastOrderno");
        frstordno = firstOrderDate.GetValue();
        lstordno = lasttOrderDate.GetValue();

    } else if (s.name == "btnSearch") {
        var empIdctrl = ASPxClientControl.GetControlCollection().GetByName("Employeeid");
        var empNamectrl = ASPxClientControl.GetControlCollection().GetByName("Employeename");
        var ucodectrl = ASPxClientControl.GetControlCollection().GetByName("Uniformcode");
        var ucodeDescctrl = ASPxClientControl.GetControlCollection().GetByName("Ucodedesc");
        var empAddctrl = ASPxClientControl.GetControlCollection().GetByName("Empaddress");
        var startDatectrl = ASPxClientControl.GetControlCollection().GetByName("EmpStartDate");
        var empId = empIdctrl.GetValue();
        var empName = empAddctrl.GetValue();
        var ucode = ucodectrl.GetValue();
        var ucodeDesc = ucodeDescctrl.GetValue();
        var ucodeAdd = ucodeAddctrl.GetValue();
        var startDate = startDatectrl.GetValue();
    }
}

function showUserCreate(s, e) {
    var isenabledCtrl = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var userActiveCtrl = ASPxClientControl.GetControlCollection().GetByName("UsrActive");

    isenabled = isenabledCtrl != null ? isenabledCtrl.GetValue() : false;
    var userRender = document.getElementById("UserctrlRender");
    if (isenabled) {
        userActiveCtrl.SetVisible(true);
        $.ajax({
            url: "/Employee/getUserCreate/",
            type: "post",
            success: function (response) {
                if (response != null) {

                    userRender.innerHTML = "";
                    userRender.innerHTML = response;
                    MVCxClientUtils.FinalizeCallback();
                }
            }
        });
    }
    else {
        userActiveCtrl.SetVisible(false);
        userRender.innerHTML = "";
    }
}

function SaveWelcomeText(s, e) {
    var htmlEdit = ASPxClientControl.GetControlCollection().GetByName("HtmlEditor");
    var htmlTxt = htmlEdit.GetHtml();
    if (htmlTxt != "") {
        $.ajax({
            url: "/Settings/SaveWelcomeText/",
            type: "post",
            data: { 'htmlText': htmlTxt },
            success: function (resp) {
                if (resp != "") {
                    window.location.reload();
                }
            }
        });
    }
}

function GetReport(s, e) {
    var rndPanel = ASPxClientControl.GetControlCollection().GetByName("RolloutFilter");
    if (rndPanel != null) {
        rndPanel.SetCollapsed(true);
    }
    var chkLstReportCtrl = ASPxClientControl.GetControlCollection().GetByName("checkListReport");
    var reportNameCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbReportNames");
    var reportTypesCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbReportTypes");
    var embroCtrl = ASPxClientControl.GetControlCollection().GetByName("chkIncEmbroidory");
    var uncnfCtrl = ASPxClientControl.GetControlCollection().GetByName("chkShowUnconfirm");
    var items = [];
    var selItems = [];
    if (chkLstReportCtrl != null) {
        for (var i = 0; i < chkLstReportCtrl.GetItemCount() ; i++) {
            items.push(chkLstReportCtrl.GetItem(i));
        }
    }
    if (items.length > 0) {
        for (var i = 0; i < items.length ; i++) {
            if (items[i].selected) {
                selItems.push(items[i].text);
            }
        }
    }
    //   var chkLstReport = chkLstReportCtrl != null?chkLstReportCtrl.GetValue():"";
    var reportName = reportNameCtrl != null ? reportNameCtrl.GetValue() != null ? reportNameCtrl.GetValue() : "" : "";
    var reportTypes = reportTypesCtrl != null ? reportTypesCtrl.GetVisible() ? reportTypesCtrl.GetValue() != null ? reportTypesCtrl.GetValue() : "0" : "" : "0";
    var embro = embro != null ? embro.GetValue() : false;
    var uncnf = uncnf != null ? uncnf.GetValue() : false;
    var gridview = ASPxClientControl.GetControlCollection().GetByName("RolloutGridView");
    gridview.PerformCallback({ selRollout: selItems, reportName: reportName, reportTypes: reportTypes, embro: embro, uncnf: uncnf, iscallback: false });

    //List<string> selRollout = null, string reportName = "", string reportTypes = "", bool embro = false, bool uncnf = false

    //$.ajax({
    //    url: "/Report/RolloutGridViewPartial/",
    //    type: "POST",
    //    data: { 'selRollout': selItems, 'reportName': reportName, 'reportTypes': reportTypes, 'embro': embro, 'uncnf': uncnf },
    //    success:function(response)
    //    {

    //    }
    //});


}
function toggleReportType(s, e) {
    var reportNameCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbReportNames");
    var chkReportTypeCtrl = ASPxClientControl.GetControlCollection().GetByName("cmbReportTypes");
    if (chkReportTypeCtrl != null) {
        var value = reportNameCtrl.GetValue();
        if (value != "1") {

            chkReportTypeCtrl.SetVisible(false);
        }
        else {
            chkReportTypeCtrl.SetVisible(true);
        }
    }
}



function GetForgetPassword() {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var popUp = ASPxClientControl.GetControlCollection().GetByName("ResetPwdpop");
    $.ajax({

        url: "/User/ResetPassword1/",
        type: "get",
        success: function (response) {
            loadPopup.Hide();

            if (response != "" && response != null) {
                var popUpDiv = document.getElementById("forgetpwdContent");
                popUpDiv.innerHTML = "";
                popUpDiv.innerHTML = response;
                popUp.Show();
                MVCxClientUtils.FinalizeCallback();
            }
            else {
                loadPopup.Hide();
            }
        },
        error: function () {
            loadPopup.Hide();
        }
    });
}

function ResetPassword(s, e) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    var popUp = ASPxClientControl.GetControlCollection().GetByName("ResetPwdpop");
    var userIdCtrl = ASPxClientControl.GetControlCollection().GetByName("fpwdUserId");
    var surNameCtrl = ASPxClientControl.GetControlCollection().GetByName("fpwdSurName");
    var foreNameCtrl = ASPxClientControl.GetControlCollection().GetByName("fpwdFrstName");

    var userId = userIdCtrl != null ? userIdCtrl.GetValue() != null && userIdCtrl.GetValue() != "" ? userIdCtrl.GetValue() : "" : "";
    var foreName = foreNameCtrl != null ? foreNameCtrl.GetValue() != null && foreNameCtrl.GetValue() != "" ? foreNameCtrl.GetValue() : "" : "";
    var surName = surNameCtrl != null ? surNameCtrl.GetValue() != null && surNameCtrl.GetValue() != "" ? surNameCtrl.GetValue() : "" : "";
    if (userId != "" && foreName != "" && surName != "") {
        $.ajax({
            url: "/User/ResetPassword/",
            type: "POST",
            data: { 'userId': userId, 'foreName': foreName, 'surName': surName },
            success: function (response) {
                if (response != "success") {
                    if (response == "") {
                        alert("Please enter a valid username");
                    }
                    else {
                        alert(response);
                    }
                    loadPopup.Hide();
                }
                else {
                    alert("your new password has been sent to your registered email address");
                    popUp.Hide();
                    loadPopup.Hide();
                }
            },
            error: function () {
                loadPopup.Hide();
            }
        });
    }
    else {
        //if (userId == "") {
        //    alert("Please enter a valid username");
        //} else if (foreName == "") {
        //    alert("Please enter a valid firstname");
        //}
        //else if (surName == "") {
        //    alert("Please enter a valid surname");
        //}
        loadPopup.Hide();
    }
}


function ResetToGeneric(user, active) {
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    if (active == 'N') {
        if (confirm("The selected user is inactive would you like to continue?")) {
            if (user != null && user != "") {
                $.ajax({
                    url: "/Employee/ResetToGeneric/",
                    type: "post",
                    data: { 'user': user },
                    success: function (response) {
                        if (response == "success") {
                            alert("The password has been successfully reset");
                        }
                        loadPopup.Hide();
                    }

                });
            }
        }
        else {
            loadPopup.Hide();
        }
    }
    else {
        if (user != null && user != "") {
            $.ajax({
                url: "/Employee/ResetToGeneric/",
                type: "post",
                data: { 'user': user },
                success: function (response) {
                    if (response == "success") {
                        alert("The password has been successfully reset to the generic password");
                    }
                    loadPopup.Hide();
                }
            });

        }
    }
}


function GetReOrdProducts(s, e) {
    var styleNameArr = s.name.split("_");
    var style = styleNameArr[3];
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    if (style != "") {
        var reorderPop = ASPxClientControl.GetControlCollection().GetByName("RetReorderPop");
        $.ajax({
            url: "/Return/GetReOrderProducts/",
            type: "post",
            data: { 'Style': style, 'styleNameArr': styleNameArr },
            success: function (response) {
                if (response != null && response != "") {
                    $.ajax({
                        url: "/Return/GetReOrderProductsDesc/",
                        type: "post",
                        data: { 'Style': style, },
                        success: function (StyleResp) {
                            var Retundiv = document.getElementById("ReOrderPop");
                            Retundiv.innerHTML = "";
                            Retundiv.innerHTML = response;
                            reorderPop.SetHeaderText("Reorder for Orderno: <b>" + styleNameArr[1] + "</b> &nbsp; &nbsp; &nbsp; Product: <b>" + StyleResp + "</b>&nbsp; &nbsp; &nbsp; Colour: <b>" + styleNameArr[4] + "</b>&nbsp; &nbsp; &nbsp; Size: <b>" + styleNameArr[6] + "</b>&nbsp; &nbsp; &nbsp; Qty: <b>" + styleNameArr[5] + "</b>");
                            loadPopup.Hide();
                            reorderPop.Show();
                            MVCxClientUtils.FinalizeCallback();
                        }
                    });

                }
            }
        });

    }

}


function getRtnCard1(StyleID, orgStyle, caption) {
    if (StyleID != "" && StyleID != undefined) {
        var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
        loadPopup.Show();
        //var popup = ASPxClientControl.GetControlCollection().GetByName("DimAllocPop");
        var url1 = "/Home/GetCard/";
        $.ajax({
            type: "POST",
            url: url1,
            data: { 'StyleID': StyleID, 'orgStyle': orgStyle, 'caption': caption },
            success: function (response) {
                var sss = response.indexOf("Login") > -1;
                if (response != "" && !response.indexOf("Login") > -1) {
                    var dim = document.getElementById("ReOrderPop");
                    dim.innerHTML = "";
                    dim.innerHTML = response;
                    loadPopup.Hide();
                    // popup.Initialize();
                    //popup.Show();
                    MVCxClientUtils.FinalizeCallback();
                }
                else {
                    window.location = "/User/Login/";
                }
            },
            error: function () {

            }
        });
    }
    else {
        alert("try again!");
    }
}


function addTocartReturnOrder(s, e) {
    var ReorderGridview = ASPxClientControl.GetControlCollection().GetByName("ReorderGridview");
    var reorderPop = ASPxClientControl.GetControlCollection().GetByName("RetReorderPop");
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    var sitecode = ASPxClientControl.GetControlCollection().GetByName("SiteCodeCmbgroupedProducts");
    var selectedSitecode = sitecode != null ? sitecode.GetValue() != null ? sitecode.GetValue() : "" : "SITECODENULL";
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

    if (stylearr[1].indexOf(',') > -1) {
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
    var minPtsDivName = "minPtsDiv_" + stylearr[3];
    var minPtsDiv = document.getElementsByClassName(minPtsDivName)
    var desc = descStyle == undefined ? stylearr[1] : descStyle[0];
    var Spin = document.getElementsByName("spinDemandEdit_" + stylearr[1]);
    var priceId = document.getElementById("DimviewPriceinput1" + stylearr[1]);
    description = document.getElementById("LbdemandDescription" + desc).innerHTML;
    price = priceId != undefined && priceId != null ? priceId.value : priceId == undefined ? "0.0" : "0"; "0";
    qty = Spin[0].value;
    var clsName = "reqDatadim" + stylearr[1];
    var reqdatatxt = "reqdatatxtdim" + stylearr[1];
    var reqData = document.getElementsByClassName(clsName);

    if (description != "" && price != "" && price != "0" && size != undefined && price != undefined && color != undefined && size != "" && color != "" && qty != "" && qty != "0" && (selectedSitecode != "" | selectedSitecode == "SITECODENULL")) {
        selectedSitecode = selectedSitecode == "SITECODENULL" ? "" : selectedSitecode;
        $.ajax({
            url: "/Return/GetBtnStatusReturns/",
            type: "POST",
            data: { 'ordQty': stylearr[2], 'color': color, 'style': sStyle, 'qty': qty, 'orgStyl': stylearr[3] },
            success: function (response) {
                if (response == "enabled") {
                    $.ajax({
                        url: "/Return/AddToCardReturnLines/",
                        type: "POST",
                        data: { 'description': description, 'price': price, 'size': size, 'color': color, 'qty': qty, 'style': sStyle, 'orgStyl': stylearr[3], 'reason': reason, 'selectedSitecode': selectedSitecode },
                        success: function (response) {
                            if (response == "Success") {
                                loadPopup.Hide();
                                reorderPop.Hide();
                                myFunction("Reorder lines successfully added");
                                MVCxClientUtils.FinalizeCallback();
                                ReorderGridview.PerformCallback();
                                CalculateTotals();
                                Refreshpointsdiv();

                            }
                            else if (response == "qty validation") {
                                loadPopup.Hide();
                                alert("You cannot reorder above the return quantity");
                            }
                            else if (response == "size validation") {
                                loadPopup.Hide();
                                alert("You cannot reorder the same uniform");
                            }
                            else {
                                loadPopup.Hide();
                                //$.ajax({
                                //    url: "/Home/AddToCardReturnLines/",
                                //    type: "POST",
                                //    data: { 'reason': reason },
                                //    success: function (response) {
                                //        if (response != "") {
                                //            alert(response);
                                //        }
                                //        else {
                                //            alert("Try again..!");
                                //        }

                                //    }
                                //});
                            }
                        },
                        error: function () {
                            loadPopup.Hide();
                            alert("Try again!");
                        }
                    });
                }
                else {
                    // document.getElementById("ErrorMessage").style.display = 'block';
                    loadPopup.Hide();
                    getEntitlementDemandSwatch(stylearr[1], stylearr[3], 1);
                }
            }
        });

    } else {
        if (price == "" || price == null || price == undefined || price == "0") {
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
        } else if (selectedSitecode == "") {
            alert("Please select a site code");
        }
        else if (reqtxt[0].value == "") {
            alert("Please select Required leg length");
        }
    }
}

function RefreshReorderGrid(s, e) {
    var ReorderGridview = ASPxClientControl.GetControlCollection().GetByName("ReorderGridview");
    ReorderGridview.PerformCallback();
    CalculateTotals();
    Refreshpointsdiv();
}

function CalculateTotals() {
    var totGoodsCtrl = ASPxClientControl.GetControlCollection().GetByName("txtTotGoods");
    var carrierChargesCtrl = ASPxClientControl.GetControlCollection().GetByName("txtCarrierCharges");
    var ordTotalCtrl = ASPxClientControl.GetControlCollection().GetByName("txtOrdTotal");
    var VATCtrl = ASPxClientControl.GetControlCollection().GetByName("txtVAT");
    var vatspanCtrl = document.getElementById("vatspan");
    var grndTotCtrl = ASPxClientControl.GetControlCollection().GetByName("txtGrndTot");
    var totGoodsReOrdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtTotGoodsReord");
    var carrierChargesReOrdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtCarrierChargesReord");
    var ordTotalReOrdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtOrdTotalReord");
    var vatspanReOrdCtrl = document.getElementById("vatspanReord");
    var VATReOrdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtVATReord");
    var grndTotReOrdCtrl = ASPxClientControl.GetControlCollection().GetByName("txtGrndTotReord");
    $.ajax({
        url: "/Return/GetRetReordTotals/",
        type: "post",
        success: function (response) {
            if (response != null) {
                if (response.length > 0) {
                    if (totGoodsCtrl != null) {
                        for (var j = 0; j < response.length; j++) {
                            if (response[j].isreturn) {
                                totGoodsCtrl.SetValue(response[j].Total);
                                carrierChargesCtrl.SetValue(response[j].carriage);
                                ordTotalCtrl.SetValue(response[j].ordeTotal);
                                vatspanCtrl.innerHTML = response[j].vatSpan;
                                VATCtrl.SetValue(response[j].totalVat);
                                grndTotCtrl.SetValue(response[j].gross);

                            }
                            if (response[j].isreord) {
                                totGoodsReOrdCtrl.SetValue(response[j].Total);
                                carrierChargesReOrdCtrl.SetValue(response[j].carriage);
                                ordTotalReOrdCtrl.SetValue(response[j].ordeTotal);
                                vatspanReOrdCtrl.innerHTML = response[j].vatSpan;
                                VATReOrdCtrl.SetValue(response[j].totalVat);
                                grndTotReOrdCtrl.SetValue(response[j].gross);

                            }
                        }
                    }
                    Refreshpointsdiv();
                }
            }
        }
    })
}
//
function Refreshpointsdiv() {
    var pointsDiv = document.getElementById("pointsDivReturns");
    $.ajax({
        url: "/Return/GetPointsDivReturns/",
        type: "POST",
        success: function (response) {
            if (response != "") {
                pointsDiv.innerHTML = response;
            }
        }
    });
}

function GetAllReturnHeader(s, e) {
    var acceptBtn = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    acceptBtn.SetEnabled(false);
    loadPopup.Show();
    $.ajax({
        type: "POST",
        url: "/Return/AcceptReturn/",
        success: function (response) {
            if (response.results != null) {
                if (response.type = "success" && response.results.length > 0) {
                    var message = "";
                    for (var k = 0; k < response.results.length; k++) {
                        if (response.results[k].IsReturn) {
                            if (response.results[k].isedit) {
                                message = message + "Your uniform return order has been successfully updated,order reference:" + response.results[k].OrderNo + " (" + response.results[k].EmployeeId + ")." + response.results[k].OrderConfirmation + ". \n\n\n";
                            }
                            else {
                                message = message + "Your uniform return order has been successfully placed,order reference:" + response.results[k].OrderNo + " (" + response.results[k].EmployeeId + ")." + response.results[k].OrderConfirmation + ". \n\n\n";
                            }

                        }
                        else {
                            if (response.results[k].isedit) {
                                message = message + "Your uniform order has been successfully updated,order reference:" + response.results[k].OrderNo + " (" + response.results[k].EmployeeId + ")." + response.results[k].OrderConfirmation + ". \n\n";
                            }
                            else {
                                message = message + "Your uniform order has been successfully placed,order reference:" + response.results[k].OrderNo + " (" + response.results[k].EmployeeId + ")." + response.results[k].OrderConfirmation + ". \n\n";
                            }


                        }
                    }


                    message = message + "\n\n\n Would you like to print order confirmation? \n\n click Ok to print , click Cancel to not print";
                    if (confirm(message)) {
                        for (var i = 0; i < response.results.length; i++) {

                            if ((response.results[i].OrderConfirmationPop != "" && response.results[i].OrderConfirmationPop != null && response.results[i].OrderConfirmationPop != undefined)) {
                                if (response.results[i].IsReturn) {

                                    var rtnOrderConfirmation = ASPxClientControl.GetControlCollection().GetByName("rtnOrderConfirmation");
                                    loadPopup.Hide()
                                    var ordConfim = document.getElementById("rtnOrdeConfirm");
                                    ordConfim.innerHTML = "";
                                    ordConfim.innerHTML = response.results[i].OrderConfirmationPop;
                                    rtnOrderConfirmation.Show();
                                }
                                else {
                                    var orderConfirmationPopup = ASPxClientControl.GetControlCollection().GetByName("orderConfirmation");
                                    loadPopup.Hide()
                                    var ordConfim = document.getElementById("ordeConfirm");
                                    ordConfim.innerHTML = "";
                                    ordConfim.innerHTML = response.results[i].OrderConfirmationPop;
                                    orderConfirmationPopup.Show();
                                }
                            }
                        }
                    }
                    else {
                        window.location = "/Employee/ChangeOrdertype?orderType=return";
                    }

                    // window.location = "/Employee/ChangeOrdertype?orderType=return";
                    // acceptBtn.SetEnabled(true);
                    //loadPopup.Hide();
                }
                else if (response.type == "CarrierPrompt") {

                }
                else if (response.type == "CollectPrompt") {
                    var ReturnCollection = ASPxClientControl.GetControlCollection().GetByName("ReturnCollection");
                    if (ReturnCollection != null) {
                        $.ajax({
                            type: "POST",
                            url: "/Return/GetCollectionPop/",
                            success: function (response) {
                                if (response != null) {
                                    var doc = document.getElementById("ReturnCollectionPop");
                                    doc.innerHTML = "";
                                    doc.innerHTML = response;
                                    ReturnCollection.Show();
                                    MVCxClientUtils.FinalizeCallback();
                                }
                            }
                        });
                        //ReturnCollectionPop

                    }
                }

            }
            else if (response.type == "CarrierPrompt") {
                alert("Please select a carrier style");
                window.location.reload();
            }
            else if (response.type == "noelements") {
                alert("Please select  atleast one line to proceed");
                acceptBtn.SetEnabled(true);
            }
            else if (response.type == "CollectPrompt") {
                acceptBtn.SetEnabled(true);
                loadPopup.Hide();
                var ReturnCollection = ASPxClientControl.GetControlCollection().GetByName("ReturnCollection");
                if (ReturnCollection != null) {
                    $.ajax({
                        type: "POST",
                        url: "/Return/GetCollectionPop/",
                        success: function (response) {
                            if (response != null) {
                                var doc = document.getElementById("ReturnCollectionPop");
                                doc.innerHTML = "";
                                doc.innerHTML = response;
                                ReturnCollection.Show();
                                loadPopup.Hide();
                                MVCxClientUtils.FinalizeCallback();
                            }
                        }
                    });
                    //ReturnCollectionPop

                }
            }
            else {
                acceptBtn.SetEnabled(true);
                loadPopup.Hide();
            }
        },
        error: function (response) {
            acceptBtn.SetEnabled(true);
            loadPopup.Hide();
        }
    });
}

function ChangeUcodePointsEmployeeGrid(s, e) {
    var allInfo = s.name.split('_');
    // var ucode = allInfo.length > 0 ? allInfo[2] : "";
    var employeeId = allInfo.length > 0 ? allInfo[1] : "";
    var totalPointsspan = "TotalPointsSpan_" + employeeId;
    var pointsUsedSpan = "PointsUsedSpan_" + employeeId;
    var selectedUcodeCtrl = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var selectedUcode = selectedUcodeCtrl != null ? selectedUcodeCtrl.GetValue() != null ? selectedUcodeCtrl.GetValue() : "" : "";
    if (selectedUcode != "") {
        $.ajax({
            url: "/Employee/ChangePointsByEmp/",
            data: { 'emp': employeeId, 'ucode': selectedUcode },
            type: "post",
            success: function (response) {
                if (response != null) {
                    var totalPts = document.getElementById(totalPointsspan);
                    var usedPts = document.getElementById(pointsUsedSpan);
                    totalPts.innerHTML = "";
                    usedPts.innerHTML = "";
                    totalPts.innerHTML = response.TotalPoints;
                    usedPts.innerHTML = response.UsedPoints;
                }
            }
        });
    }
}

function redirect(s, e) {
    if (s.name == "orderConfirmation") {
        var rtnCnfPop = ASPxClientControl.GetControlCollection().GetByName("rtnOrderConfirmation");
        if (rtnCnfPop != null) {
            if (rtnCnfPop.IsVisible()) {

            }
            else {
                /// sasi(14-12-20)
                //window.history.back();
                //window.location = "/Employee/Index/";
                if (document.referrer.indexOf("Home") > -1) {
                    window.location = "/Employee/Index/";
                }
                else {
                    window.location = document.referrer;
                }
            }
        }
        else {
            /// sasi(14-12-20)
            //window.history.back();
            // window.location = "/Employee/Index/";
            if (document.referrer.indexOf("Home") > -1) {
                window.location = "/Employee/Index/";
            }
            else {
                window.location = document.referrer;
            }
        }
    }
    else {
        var rtnCnfPop = ASPxClientControl.GetControlCollection().GetByName("orderConfirmation");

        if (rtnCnfPop != null) {
            if (rtnCnfPop.IsVisible()) {

            }
            else {
                /// sasi(14-12-20)
                //window.history.back();
                //  window.location = "/Employee/ChangeOrdertype?orderType=return";
                if (document.referrer.indexOf("Home") > -1) {
                    window.location = "/Employee/Index/";
                }
                else {
                    window.location = document.referrer;
                }
            }
        }
        else {
            /// sasi(14-12-20)
            //window.history.back();
            // window.location = "/Employee/ChangeOrdertype?orderType=return";
            if (document.referrer.indexOf("Home") > -1) {
                window.location = "/Employee/Index/";
            }
            else {
                window.location = document.referrer;
            }
        }
    }
}

//function 

function SettleReturnCollectionInfo(s, e) {
    var sts = s.name != null ? s.name.indexOf('Yes') > -1 ? true : false : false;
    var ReturnCollection = ASPxClientControl.GetControlCollection().GetByName("ReturnCollection");
    var cntNameCtrl = ASPxClientControl.GetControlCollection().GetByName("rtnCollContNam");
    var cntNoCtrl = ASPxClientControl.GetControlCollection().GetByName("rtnCollContNo");
    var cntEmailCtrl = ASPxClientControl.GetControlCollection().GetByName("rtnCollEmail");
    var cntName = cntNameCtrl != null ? cntNameCtrl.GetValue() != null ? cntNameCtrl.GetValue() : "" : "";
    var cntNo = cntNoCtrl != null ? cntNoCtrl.GetValue() != null ? cntNoCtrl.GetValue() : "" : "";
    var cntEmail = cntEmailCtrl != null ? cntEmailCtrl.GetValue() != null ? cntEmailCtrl.GetValue() : "" : "";
    if (sts) {
        if (cntName != "" && cntNo != "" && cntEmail != "") {
            if (validateEmail(cntEmail)) {
                $.ajax({
                    url: "/Return/SaveCntInfo/",
                    type: "POST",
                    data: { 'cntName': cntName, 'cntNo': cntNo, 'cntEmail': cntEmail },
                    success: function (response) {
                        if (response != "") {
                            ReturnCollection.Hide();
                        }
                    }
                });
            }
            else {
                alert("Please enter a valid emailid");
            }
        }
        else {
            if (cntName == "") {
                alert("Please enter a contact name");
            } else if (cntNo == "") {
                alert("Please enter a contact number");
            }
            else {
                alert("Please enter a contact email");
            }
        }
    }
    else {
        $.ajax({
            url: "/Return/ChangeCollectionSts/",
            type: "POST",
            success: function (response) {
                if (response) {
                    ReturnCollection.Hide();
                }
            }
        });

    }

}


function ChangeReasonSelLines(s, e) {
    var chkbox = ASPxClientControl.GetControlCollection().GetByName(s.name);
    var grid = ASPxClientControl.GetControlCollection().GetByName("EditReturnOrderGridview");
    if (chkbox.GetValue()) {
        var count = grid.GetSelectedRowCount();
        if (count > 0) {
            grid.GetSelectedFieldValues('OrderNo;LineNo;StyleId;ColourId;SizeId;IsSelect', GetReasonValues);
        }
        else {
            chkbox.SetValue(false);
            alert("Please select a line");
        }
    }
}
function AcceptReturnLines(s, e) {
    var ReturnGrid = ASPxClientControl.GetControlCollection().GetByName("EditReturnOrderGridview");
    var index = ReturnGrid.GetFocusedRowIndex();
    ReturnGrid.GetSelectedFieldValues('OrderNo;LineNo;StyleId;ColourId;SizeId;IsSelect', GetSelectedRtnLines);
}
function GetSelectedRtnLines(selectedValues) {
    var noReason = [];
    var allReason = "";
    var noQty = [];
    var selArr = [];
    var chkbox = ASPxClientControl.GetControlCollection().GetByName("Applyreasontoalllines");
    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");
    loadPopup.Show();
    if (selectedValues != null && selectedValues != "") {

        for (var i = 0; i < selectedValues.length; i++) {
            if (selectedValues[i][5] == false) {
                var name = "cmbRtnReason_" + selectedValues[i][0] + "_" + selectedValues[i][1];
                var name2 = "txtBoxOrdQty_" + selectedValues[i][0] + "_" + selectedValues[i][1];
                var cmbReasonCtrl = ASPxClientControl.GetControlCollection().GetByName(name);
                var chkBxVal = chkbox.GetValue() == null ? false : chkbox.GetValue();
                var cmbReason = cmbReasonCtrl != null ? cmbReasonCtrl.GetValue() != null ? cmbReasonCtrl.GetValue() : "" : "";
                var retQtyCtrl = ASPxClientControl.GetControlCollection().GetByName(name2);
                var retQty = retQtyCtrl != null ? retQtyCtrl.GetValue() != null ? retQtyCtrl.GetValue() : 0 : 0;
                if (cmbReason == "" && chkBxVal == false && selectedValues[i][5] == false) {
                    var obj = { 'name': name };
                    noReason.push(obj);
                }
                if (retQty == 0 && selectedValues[i][5] == false) {
                    var obj = { 'name': name2 };
                    noQty.push(obj);
                }
                if (chkBxVal) {
                    allReason = cmbReason == "" ? allReason : cmbReason;
                    var obj = { 'OrderNo': selectedValues[i][0], 'StyleId': selectedValues[i][2], 'LineNo': selectedValues[i][1], 'ColourId': selectedValues[i][3], 'SizeId': selectedValues[i][4], 'Reason': allReason, 'RtnQty': retQty };
                    selArr.push(obj);
                }
                else {
                    var obj = { 'OrderNo': selectedValues[i][0], 'StyleId': selectedValues[i][2], 'LineNo': selectedValues[i][1], 'ColourId': selectedValues[i][3], 'SizeId': selectedValues[i][4], 'Reason': cmbReason, 'RtnQty': retQty };
                    selArr.push(obj);
                }
            }

        }
        if (noReason.length == 0 && noQty.length == 0) {
            $.ajax({
                url: "/Return/SelectedReturnOrderLines/",
                type: "post",
                data: { 'rtnLines': selArr },
                success: function (response) {
                    if (response == "") {

                        loadPopup.Hide();
                    }
                    else {
                        window.location = response;
                    }
                }
            });
        }
        else {
            if (noReason.length > 0) {
                var reasonct = ASPxClientControl.GetControlCollection().GetByName(noReason[0].name);
                alert("Please enter a valid reason for selected lines");
                if (reasonct != null) {
                    reasonct.Focus();
                }
            }
            else if (noQty.length > 0) {
                var Qtyct = ASPxClientControl.GetControlCollection().GetByName(noQty[0].name);
                alert("Please enter a return quantity for selected lines");
                if (Qtyct != null) {
                    Qtyct.Focus();
                }
            }
            loadPopup.Hide();
        }
    }
    else {
        loadPopup.Hide();
        alert("Please select a line to continue");
    }
}

function GetReasonValues(selectedValues) {
    var reason = "";
    var chkbox = ASPxClientControl.GetControlCollection().GetByName("Applyreasontoalllines");
    if (selectedValues != null) {
        if (selectedValues.length > 0) {
            for (var i = 0; i < selectedValues.length; i++) {
                if (selectedValues[i][5] == false) {
                    var name = "cmbRtnReason_" + selectedValues[i][0] + "_" + selectedValues[i][1];
                    var cmbReasonCtrl = ASPxClientControl.GetControlCollection().GetByName(name);
                    var cmbReason = cmbReasonCtrl != null ? cmbReasonCtrl.GetValue() != null ? cmbReasonCtrl.GetValue() : "" : "";
                    if (cmbReason != "") {
                        reason = cmbReason;
                    }
                }
            }
            if (reason != "") {
                for (var i = 0; i < selectedValues.length; i++) {
                    if (selectedValues[i][5] == false) {
                        var name = "cmbRtnReason_" + selectedValues[i][0] + "_" + selectedValues[i][1];
                        var cmbReasonCtrl = ASPxClientControl.GetControlCollection().GetByName(name);
                        cmbReasonCtrl.SetValue(reason);
                    }
                }
            } else {
                chkbox.SetValue(false);
                alert("Please select reason for atleast one line");
            }
        }
    }

}
function PrintReturns(orderNo) {

    var loadPopup = ASPxClientControl.GetControlCollection().GetByName("ForgotPassLoadingPanel1");

    loadPopup.Show();
    $.ajax({
        type: "POST",
        url: "/OrderDisplay/PrintReturns/",
        data: { 'OrderNo': orderNo },
        success: function (response) {
            if (response != "") {
                var rtnOrderConfirmation = ASPxClientControl.GetControlCollection().GetByName("ProrderConfirmation");
                loadPopup.Hide()
                var ordConfim = document.getElementById("prordeConfirm");
                ordConfim.innerHTML = "";
                ordConfim.innerHTML = response;
                rtnOrderConfirmation.Show();
            }
        }
    });
}
function ItsCallBack(s, e) {
    e.customArgs["iscallback"] = true;

}


function OrderEditRT(orderNo, empId) {
    $.ajax({
        url: "/OrderDisplay/SetEmployee/",
        type: "post",
        data: { 'empId': empId },
        success: function (resp) {
            if (resp.toLowerCase().indexOf("emp") > -1 == false) {
                window.location = "/Return/ReturnReorderEdit?ordeNo=" + orderNo;
            }
            else {
                alert(resp);
            }
        }
    });

}