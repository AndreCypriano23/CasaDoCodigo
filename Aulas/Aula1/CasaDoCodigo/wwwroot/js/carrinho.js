//Vou encapsular a classe dentro de um escopo

class Carrinho {

    clickIncremento(btn) {

        let data = this.getData(btn);
        data.Quantidade++;
        this.postQuantidade(data);

        //é um breakPoint debugger;
        //debugger
    }


    clickDecremento(btn) { 

        let data = this.getData(btn);
        data.Quantidade--;
        this.postQuantidade(data);

    }

    updateQuantidade(input) {

        let data = this.getData(input);
        this.postQuantidade(data);

    }


    getData(elemento) {
        //vou usar o Jquery, que já vem instalado
        var linhaDoItem = $(elemento).parents('[item-id]');//para pegar a div pai que fica logo depois do foreach
        var itemId = $(linhaDoItem).attr('item-id');
        var novaQtde = $(linhaDoItem).find('input').val();//localizar um elemento abaixo, um input

         return {
            Id: itemId,
            Quantidade: novaQtde
        };
    }

    postQuantidade(data) {

        //Chamada AJAX
        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data) /*Transformei o objeto data em string */
        });

    }




}


//Escopo global
var carrinho = new Carrinho();


