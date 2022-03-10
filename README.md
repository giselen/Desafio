# Desafio
Projeto Desenvolvido em .Net, para executar necessita ter  o .Net Core e o SQL Server na máquina, não utilizei o docker então executei o Example.Charge.API, configurei a string de conexão de acordo com minha base de dados, utilizei o Swagger para testar as rotas.
![image](https://user-images.githubusercontent.com/37514074/157601662-785c132c-b757-4eaa-9872-02d7e3162f95.png)

1° Rota: http://localhost:5000/api/Person método Get -> Retorna todas as pessoas cadastradas na tabela PhoneNumberType![image](https://user-images.githubusercontent.com/37514074/157602099-92e5b34d-6af8-4613-92d1-7722d77d107a.png)

2° Rota: http://localhost:5000/api/Person/{id} -> Retorna as informações da tabela PersonPhone mas pelo id PhoneNumberTypeID![image](https://user-images.githubusercontent.com/37514074/157602661-5ba1cf7f-66a2-4760-8f55-d44a8961fabe.png)Exemplo utilizando id igual a 1
![image](https://user-images.githubusercontent.com/37514074/157602771-b11ef9c9-961a-4383-b73d-5df4f013eeb4.png)Exemplo utilizando id igual a 2

3° Rota: http://localhost:5000/api/Person Método Post -> Adiciona um novo número![image](https://user-images.githubusercontent.com/37514074/157603092-1431a21b-50bb-4521-be18-8851a4856e80.png)

4° Rota: http://localhost:5000/api/Person/{id}/{número telefone}/{id tipo telefone} -> método de atualização, além de passar os parametros na url, vai precisar passar as informações que será atualizadas, as informações da url serão utilizadas como um filtro![image](https://user-images.githubusercontent.com/37514074/157603919-f728b1a3-24da-411b-a189-33db19c98f03.png)

5: Rota: http://localhost:5000/api/Person/{BusinessEntityID}/{PhoneNumber}/{PhoneNumberTypeID} Método Delete -> Deleta informação da tabela Person.PersonPhone


