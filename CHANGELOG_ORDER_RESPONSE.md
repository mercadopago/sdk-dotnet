# Changelog Order Response

## [2024-03-21] - Atualização da estrutura Order Response

### Alterações
- Adicionada propriedade `ExternalCode` na classe `OrderItems` para suportar o código externo do item

### Análise de Compatibilidade
A estrutura atual do SDK já suporta a maioria dos campos presentes no JSON de exemplo, com as seguintes classes principais:

- `Order`: Classe principal que representa a ordem
- `OrderTransaction`: Representa as transações da ordem
- `OrderPayment`: Representa os pagamentos da ordem
- `OrderPaymentMethod`: Representa o método de pagamento
- `OrderItems`: Representa os itens da ordem
- `OrderIntegrationData`: Representa os dados de integração

### Estrutura Atual vs JSON
A estrutura atual do SDK já estava bem alinhada com o contrato JSON, necessitando apenas da adição do campo `external_code` na classe `OrderItems`.

### JSON de Exemplo
```json
{
  "id": "ORD01HRYFWNYRE1MR1E60MW3X0T2P",
  "type": "online",
  "processing_mode": "automatic",
  "external_reference": "ext_ref_1234",
  "description": "some description",
  "marketplace": "NONE",
  "marketplace_fee": "10.00",
  "total_amount": "1000.00",
  "total_paid_amount": "1000.00",
  "country_code": "BRA",
  "user_id": "1245621468",
  "status": "processed",
  "status_detail": "accredited",
  "capture_mode": "automatic_async",
  "created_date": "2024-11-21T14:19:14.727Z",
  "last_updated_date": "2024-11-21T14:19:18.489Z",
  "integration_data": {
    "application_id": "130106526144588"
  },
  "transactions": {
    "payments": [
      {
        "id": "PAY01JD7HETD7WX4W31VA60R1KC8E",
        "amount": "1000.00",
        "paid_amount": "1000.00",
        "expiration_time": "P1D",
        "date_of_expiration": "2024-01-01T00:00:00.000-03:00",
        "reference_id": "22dvqmsf4yc",
        "status": "processed",
        "status_detail": "accredited",
        "payment_method": {
          "id": "master",
          "type": "credit_card",
          "token": "677859ef5f18ea7e3a87c41d02c3fbe3",
          "statement_descriptor": "LOJA X",
          "installments": 1
        }
      }
    ]
  },
  "items":[
    {
      "external_code": "item_external_code",
      "category_id": "category_id",
      "title": "Some item title",
      "description": "Some item description",
      "unit_price": "1000.00",
      "type": "item type",
      "picture_url": "https://mysite.com/img/item.jpg",
      "quantity": 1
    }
  ]
}
``` 