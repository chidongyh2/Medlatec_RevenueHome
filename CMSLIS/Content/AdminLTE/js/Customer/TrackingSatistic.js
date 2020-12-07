function initMap() {
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("tracking-map"), {
        zoom: 8,
        center: new google.maps.LatLng(21.0220951, 105.850696),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var marker, i;

    for (i = 0; i < locations.length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i].lat, locations[i].lng),
            map: map,
            label: {
                text: locations[i].userFullName,
                fontSize: '14px',
                fontWeight: 'bold',
                color: '#00c0ef'
            },
            icon: {
                labelOrigin: new google.maps.Point(75, 32),
                size: new google.maps.Size(32, 32),
                anchor: new google.maps.Point(16, 32)
            }
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                console.log(marker, locations[i]);
                //infowindow.setContent(locations[i].userFullName);
                //infowindow.open(map, marker);
            }
        })(marker, i));
    }
}