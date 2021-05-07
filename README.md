# dotnet-json-benchmark

Para gerar um JSON grande, basta executar (precisa ser no Linux, WSL ou Git Bash):

```bash
./generate-huge-json.sh
```

Leva um tempo para executar, então só execute quando necessário. Já estou disponibilizando um pronto :)

Para alterar a quantidade total de itens que devem ser gerados, altere a variável ``json_total``. O padrão está 1 milhão.

A cada "step" o script irá gravar o que foi processado no arquivo, para evitar lentidão por gravação intensiva, mas também não ocupando muito a memória do computador. Caso queira deixar esse "step" diferente, altere a variável ``json_step``. O padrão está 10 mil.