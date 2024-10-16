# Monitoramento - Cidades Inteligentes

Este é um projeto responsável pelo monitoramento da cidade, através do registro de leituras de sensores em determinadas áreas, para detectar desastres e regiões que necessitem de alguma manutenção, como por exemplo a realização de irrigação automática.

## Entidades Existentes

- **Sensor**
- **Leitura Sensor**
- **Área Verde**
- **Alerta Desastre**
- **Irrigação Inteligente**
- **Usuário** (para propósitos de autenticação)

### Entidades independentes:

- **Sensor**
- **Área Verde**
- **Alerta Desastre**

### Entidades que dependem de outras:

- **Leitura Sensor** (n:1 -> Sensor)
- **Irrigação Inteligente** (n:1 -> Área Verde)

## Instruções para a execução do projeto

1. Baixe o arquivo `MONITORAMENTO.zip`.
2. Descompacte o arquivo.
3. Abra o Docker no computador.
4. Importe o projeto descompactado para o **Microsoft Visual Studio**.
5. Ao carregar o projeto, aparecerá no topo do menu a opção de executar o projeto utilizando o **Dockerfile**. Clique nesta opção.

O projeto será executado e o navegador será aberto automaticamente com a interface visual da API (**Swagger**).

## Testando a API

Agora você pode testar a API através do navegador.

É possível também copiar a URL do navegador e testar os endpoints utilizando o **Postman** ou **Insomnia**.

A collection com todos os endpoints se encontra no arquivo: `Collection-API.zip`.

### Autenticação

O token que é utilizado para os endpoints está armazenado como uma variável de ambiente no **Insomnia**. É preciso editá-la ao realizar o cadastro/login.
