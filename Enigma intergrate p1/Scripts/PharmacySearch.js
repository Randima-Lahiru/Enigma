    var map = null;
    var radius_circle;
    var markers_on_map = [];
    var geocoder;
    var infowindow;
    var all_locations = [];

        $(document).ready(function () {
            var latlng = new google.maps.LatLng(6.7950498, 79.8941967); //you can use any location as center on map startup
            var myOptions = {
                zoom: 1,
                center: latlng,
                mapTypeControl: true,
                mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU },
                navigationControl: true,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
            geocoder = new google.maps.Geocoder();
            google.maps.event.addListener(map, 'click', function () {
                if (infowindow) {
                    infowindow.setMap(null);
                    infowindow = null;
                }
            });
        });

    function showCloseLocations() {
        var i;
        //var radius_circle;
        var radius_km = $('#radius_km').val();
        var address = $('#address').val();

        //remove all radii and markers from map before displaying new ones
        if (radius_circle) {
            radius_circle.setMap(null);
            radius_circle = null;
        }
        for (i = 0; i < markers_on_map.length; i++) {
            if (markers_on_map[i]) {
                markers_on_map[i].setMap(null);
                markers_on_map[i] = null;
            }
        }

        if (geocoder) {
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
                        var address_lat_lng = results[0].geometry.location;
                        radius_circle = new google.maps.Circle({
                            center: address_lat_lng,
                            radius: radius_km * 1000,
                            clickable: false,
                            map: map
                        });
                        if (radius_circle) map.fitBounds(radius_circle.getBounds());
                        for (var j = 0; j < all_locations.length; j++) {
                            (function (location) {
                                var marker_lat_lng = new google.maps.LatLng(location.lat, location.lng);
                                var distance_from_location = google.maps.geometry.spherical.computeDistanceBetween(address_lat_lng, marker_lat_lng); //distance in meters between your location and the marker
                                if (distance_from_location <= radius_km * 1000) {
                                    var new_marker = new google.maps.Marker({
                                        position: marker_lat_lng,
                                        map: map,
                                        title: location.name
                                    }); google.maps.event.addListener(new_marker, 'click', function () {
                                        if (infowindow) {
                                            infowindow.setMap(null);
                                            infowindow = null;
                                        }
                                        infowindow = new google.maps.InfoWindow(
                {
                    content: '<div style="color:red">' + location.name + '</div>' + " is " + distance_from_location + " meters from my location",
                    size: new google.maps.Size(150, 50),
                    pixelOffset: new google.maps.Size(0, -30)
                , position: marker_lat_lng, map: map
                });
                                    });
                                    markers_on_map.push(new_marker);
                                }
                            })(all_locations[j]);
                        }
                    } else {
                        alert("No results found");
                    }
                } else {
                    alert("Please enter a location");
                }
            });
        }
    }


function myFunction() {
    var dataObject = {};

    $.ajax({
        url: "http://localhost:43596/api/PharmacySearch/PharmacySearch",
        type: "GET",
        data: JSON.stringify(dataObject),

        contentType: "application/json",
        success: function (response) {
            for (var i = 0; i < response.length; i++) {
                var x;
                var y;
                x = parseFloat(response[i].Lat);
                y = parseFloat(response[i].Long);

                all_locations[i] = { lat: x, lng: y }
            }
            

        },
        error: function () {

        }
    });

};
















