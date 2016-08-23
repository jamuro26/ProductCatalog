
// js realizado con angular a modo muy basico, ya que no poseo mucho conocimiento, tomado de ejemplos de internet.
var app = angular.module('Module', []);


app.controller('ProductCatalog', function ($scope, $http, ProductsService) {

    $scope.productsData = null;
   

    ProductsService.GetAllRecords().then(function (d) {
        $scope.productsData = d.data; 
    }, function () {
        alert('Error Occurs'); 
    });

   

    $scope.Product = {
        Id: '',
        Name: '',
        Price: '',
        Brand: '',
        QualityInStock: '',
        Size: ''
    };

    //Limpiar los caompos de productos.
    $scope.clear = function () {
        $scope.Product.Id = '';
        $scope.Product.Name = '';
        $scope.Product.Price = '';
        $scope.Product.Brand = '';
        $scope.Product.QualityInStock = '';
        $scope.Product.Size = '';
    }

    //Agregar un nuevo Producto
    $scope.save = function () {
        if ($scope.Product.Name != "" &&
       $scope.Product.Price != "" && $scope.Product.Brand != "" && $scope.Product.QualityInStock != "" && $scope.Product.Size != "") {
            $http({
                method: 'POST',
                url: 'api/Product/PostProduct/',
                data: $scope.Product
            }).then(function successCallback(response) {
                $scope.productsData.push(response.data);
                $scope.clear();
                alert("Product Added");
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Complete all information');
        }
    };

    // Se obtiene el detalle del producto para poder editarlo.
    $scope.edit = function (data) {
        $scope.Product = { Id: data.Id, Name: data.Name, Price: data.Price, Brand: data.Brand, Size: data.Size, QualityInStock: data.QualityInStock };
    }

    // Accion para cancelar
    $scope.cancel = function () {
        $scope.clear();
    }

    // Accion para actualizar el producto
    $scope.update = function () {
        if ($scope.Product.Name != "" &&
       $scope.Product.Price != "" && $scope.Product.Brand != "" && $scope.Product.QualityInStock != "" && $scope.Product.Size != "") {
            $http({
                method: 'PUT',
                url: 'api/Product/PutProduct/' + $scope.Product.Id,
                data: $scope.Product
            }).then(function successCallback(response) {
                $scope.productsData = response.data;
                $scope.clear();
                alert("Updated Product");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Complete all information');
        }
    };

    //Borrar un producto
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: 'api/Product/DeleteProduct/' + $scope.productsData[index].Id,
        }).then(function successCallback(response) {
            $scope.productsData.splice(index, 1);
            alert("Deleted  Product");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

app.factory('ProductsService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('api/Product/GetAllProducts');
    }
    return fac;
});