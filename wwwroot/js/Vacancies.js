$(document).ready(function () {
    $.ajax({
        cache: false,
        type: "GET",
        url: "../Home/Get",
        dataType: "json",
        success: function (data) {
            var result = "";
            if (data.length > 0) {
                for (var x = 0; x < data.length; x++) {
                    var _cat = data[x].category;

                    result += '<tr style="background: none"><td  style="border: none;padding:0px;"><article class="entry"><h2 class="entry-title"><a href="blog-single.html">';
                    result += data[x].jobTitle;
                    result += '</a >' +
                        '</h2><div class="entry-meta"><ul><li class="d-flex align-items-center"><i class="bi bi-bookmark"></i> <a href="blog-single.html">Category:' + _cat + '</a></li>' +
                        '<li class="d-flex align-items-center"><i class="bi bi-clock"></i> <a href="blog-single.html"><time datetime="2020-01-01">' + data[x].publishingDate + '</time></a></li>' +
                        '<li class="d-flex align-items-center"><i class="bi bi-cash"></i> <a href="blog-single.html">' + data[x].salary + ' </a></li>' +
                        '<li class="d-flex align-items-center"><i class="bi bi-flag"></i> <a href="blog-single.html">Country: ' + data[x].country + '</a></li>' +
                        '<li class="d-flex align-items-center"><i class="bi bi-explicit"></i> <a href="blog-single.html">' + data[x].yearsOfExperience + ' </a></li>' +
                        '<li class="d-flex align-items-center"> <a href="blog-single.html">Gender :' + data[x].genderType + '</a></li>' +
                        '</ul></div> <div class="entry-content"> <p>' + data[x].description + '</p><div class="read-more"><a href="@Url.Action("Details", "Home")">More</a><a href="blog-single.html">Apply</a></div></div></article></td></tr>';
                }
            }
            else {
                result += '<article class="entry"><h2 class="entry-title"><a href="blog-single.html">No Vacancies found</a></h2></article>';
            }
            $("#CardsDiv").html(result);
            $('#table').dataTable({
                "draw": 1,
                "searching": false,
                "ordering": false
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve Jobs.');
        }
    });
    $('#BtnSearch').on('click', function () {
        var _categoryID = $("#ddl_Category").val();
        var _jobTitle = $("#ddl_JobTitle").val();
        var _salary = $("#ddl_Salary").val();
        var _country = $("#ddl_Country").val();
        var _YearsOfExperienceID = $("#ddl_YearsOfExperience").val();
        var _Description = $("#DescriptionIp").val();
        $.ajax({
            cache: false,
            type: "GET",
            url: "../Home/Get",
            data: {
                "JobTitleID": _jobTitle, "CategoryID": _categoryID,
                "Description": _Description,
                "CountryID": _country,
                "YearsOfExperienceID": _YearsOfExperienceID, "SalaryID": _salary
            },

            success: function (data) {
                var result = "";
                if (data.length > 0) {
                    for (var x = 0; x < data.length; x++) {
                        var _cat = data[x].category;

                        result += '<tr style="background: none"><td  style="border: none;padding:0px;"><article class="entry"><h2 class="entry-title"><a href="blog-single.html">';
                        result += data[x].jobTitle;
                        result += '</a >' +
                            '</h2><div class="entry-meta"><ul><li class="d-flex align-items-center"><i class="bi bi-bookmark"></i> <a href="blog-single.html">Category:' + _cat + '</a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-clock"></i> <a href="blog-single.html"><time datetime="2020-01-01">' + data[x].publishingDate + '</time></a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-cash"></i> <a href="blog-single.html">' + data[x].salary + ' </a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-flag"></i> <a href="blog-single.html">Country: ' + data[x].country + '</a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-explicit"></i> <a href="blog-single.html">' + data[x].yearsOfExperience + ' </a></li>' +
                            '<li class="d-flex align-items-center"> <a href="blog-single.html">Gender :' + data[x].genderType + '</a></li>' +
                            '</ul></div> <div class="entry-content"> <p>' + data[x].description + '</p><div class="read-more"><a href="@Url.Action("Details", "Home")">More</a><a href="blog-single.html">Apply</a></div></div></article></td></tr>';
                    }
                }
                else {
                    result += '<article class="entry"><h2 class="entry-title"><a href="blog-single.html">No Vacancies found</a></h2></article>';
                }
                $("#CardsDiv").html(result);
                $('#table').dataTable({
                    "draw": 1,
                    "searching": false,
                    "ordering": false
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Call ');
            }
        });
    });
    $("#ddl_Category").change(function () {
        var _categoryID = $(this).val();
        $.getJSON("../Home/LoadJobTitle", { categoryID: _categoryID },
            function (classesData) {
                var select = $("#ddl_JobTitle");
                select.empty();
                select.append($('<option/>', {
                    value: 0,
                    text: "All"
                }));
                $.each(classesData, function (index, itemData) {
                    select.append($('<option/>', {
                        value: itemData.value,
                        text: itemData.text
                    }));
                });
            });
    });
    $('#BtnSubmit').on('click', function () {
        var _categoryID = $("#ddl_Category").val();
        var _jobTitle = $("#ddl_JobTitle").val();
        var _salary = $("#ddl_Salary").val();
        var _country = $("#ddl_Country").val();
        var _YearsOfExperienceID = $("#ddl_YearsOfExperience").val();
        var _Description = $("#DescriptionIp").val();
        $.ajax({
            cache: false,
            type: "POST",
            url: "../Home/Get",
            data: {
                "JobTitleID": _jobTitle, "CategoryID": _categoryID,
                "Description": _Description,
                "CountryID": _country,
                "YearsOfExperienceID": _YearsOfExperienceID, "SalaryID": _salary
            },

            success: function (data) {
                var result = "";
                if (data.length > 0) {
                    for (var x = 0; x < data.length; x++) {
                        var _cat = data[x].category;

                        result += '<tr style="background: none"><td  style="border: none;padding:0px;"><article class="entry"><h2 class="entry-title"><a href="blog-single.html">';
                        result += data[x].jobTitle;
                        result += '</a >' +
                            '</h2><div class="entry-meta"><ul><li class="d-flex align-items-center"><i class="bi bi-bookmark"></i> <a href="blog-single.html">Category:' + _cat + '</a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-clock"></i> <a href="blog-single.html"><time datetime="2020-01-01">' + data[x].publishingDate + '</time></a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-cash"></i> <a href="blog-single.html">' + data[x].salary + ' </a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-flag"></i> <a href="blog-single.html">Country: ' + data[x].country + '</a></li>' +
                            '<li class="d-flex align-items-center"><i class="bi bi-explicit"></i> <a href="blog-single.html">' + data[x].yearsOfExperience + ' </a></li>' +
                            '<li class="d-flex align-items-center"> <a href="blog-single.html">Gender :' + data[x].genderType + '</a></li>' +
                            '</ul></div> <div class="entry-content"> <p>' + data[x].description + '</p><div class="read-more"><a href="@Url.Action("Details", "Home")">More</a><a href="blog-single.html">Apply</a></div></div></article></td></tr>';
                    }
                }
                else {
                    result += '<article class="entry"><h2 class="entry-title"><a href="blog-single.html">No Vacancies found</a></h2></article>';
                }
                $("#CardsDiv").html(result);
                $('#table').dataTable({
                    "draw": 1,
                    "searching": false,
                    "ordering": false
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Call ');
            }
        });
    });
});