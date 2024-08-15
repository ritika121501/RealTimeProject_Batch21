$(document).ready(function () {
    alert('heko');
    $("#categoryTable").DataTable({
        
        "ajax": {
            "url": "Category/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "categoryId", "name": "Id", "autowidth": true },
            { "data": "name", "name": "Name", "autowidth": true },
            { "data": "description", "name": "Description", "autowidth": true }
        ]
    });
});