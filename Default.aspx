<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yesbd._Default" %>
<asp:Content runat="server" ContentPlaceHolderID="HeadContent">

    <!DOCTYPE html5 PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <title>Show your Current Location in Google Maps
    </title>
    <style type="text/css">
        gb html {
            height: 100%;
        }

        body {
            height: 100%;
            margin: 0;
            padding: 0;
            background-color: #fafafa;
        }

        #map_canvas {
            height: 100%;
        }
    </style>

    <script type="text/javascript"
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyByJmQq7PkPaznZUFsH7AesFNUz82U8iOc&sensor=false">
    </script>

    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places">
    </script>

    <script type="text/javascript">
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(success);
        } else {
            alert("Geo Location is not supported on your current browser!");
        }
        function success(position) {
            //var latitude = position.coords.latitude;
            //var longitude = position.coords.longitude;
            var latitude = "22.347537";
            var longitude = "91.812332";
            var city = position.coords.locality;
            var myLatlng = new google.maps.LatLng(latitude, longitude);
            var myOptions = {
                center: myLatlng,
                zoom: 12,
                mapTypeId: google.maps.MapTypeId.SATELLITE
            };
            var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
            var marker = new google.maps.Marker({
                position: myLatlng,
                title: "lat: " + latitude + " long: " + longitude
            });

            marker.setMap(map);
            marker.setAnimation(google.maps.Animation.BOUNCE);
            var infowindow = new google.maps.InfoWindow({ content: "<b>Yes-bd</b><br/> O.R. Nizam Road," + "" + "<br /> Chittagong-4000, Bangladesh" + "" + "" });
            infowindow.open(map, marker);
        }

    </script>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%-- <div class="jumbotron">
    </div>--%>
    <br />
    <br />
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-12">

                <div id="map_canvas" style="width: 100%; height: 600px">
                </div>

            </div>
        </div>
    </div>
</asp:Content>
