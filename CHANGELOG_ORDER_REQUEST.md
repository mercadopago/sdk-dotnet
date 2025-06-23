# Changelog Order Request

## Análise de Compatibilidade - OrderCreateRequest

### Estrutura Atual vs. Nova Estrutura

Após uma análise detalhada das classes envolvidas, foi constatado que todas as propriedades necessárias já estão presentes nas classes existentes. Não são necessárias alterações estruturais.

### Classes Analisadas e Suas Propriedades

#### OrderCreateRequest
- Todas as propriedades de nível superior estão presentes e corretas
- Mantém a estrutura hierárquica necessária para o contrato

#### OrderPaymentMethodRequest
- Já possui todas as propriedades necessárias incluindo:
  - `Id`
  - `Type`
  - `Token`
  - `StatementDescriptor`
  - `Installments`

#### OrderPayerRequest
- Contém toda a estrutura necessária para dados do pagador:
  - Informações básicas (email, nome, sobrenome)
  - `EntityType`
  - `Identification` (tipo e número do documento)
  - `Phone` (código de área e número)
  - `Address` (endereço completo)

#### OrderItemsRequest
- Possui todos os campos necessários para os itens:
  - `Title`
  - `UnitPrice`
  - `Quantity`
  - `Description`
  - `ExternalCode`
  - `CategoryId`
  - `Type`
  - `PictureUrl`

### Conclusão

A estrutura atual do SDK já está completamente preparada para lidar com o contrato fornecido. Não são necessárias alterações nas classes existentes.

## JSON de Exemplo
```json
{
  "type": "online",
  "total_amount": "1000.00",
  "external_reference": "ext_ref_1234",
  "capture_mode": "automatic_async",
  "transactions": {
    "payments": [
      {
        "amount": "1000.00",
        "expiration_time": "P1D",
        "payment_method": {
          "id": "master",
          "type": "credit_card",
          "token": "677859ef5f18ea7e3a87c41d02c3fbe3",
          "installments": 1,
          "statement_descriptor": "LOJA X"
        }
      }
    ]
  },
  "processing_mode": "automatic",
  "description": "some description",
  "payer": {
    "entity_type": "individual",
    "email": "test_123@testuser.com",
    "first_name": "John",
    "last_name": "Doe",
    "identification": {
      "type": "CPF",
      "number": "15635614680"
    },
    "phone": {
      "area_code": "55",
      "number": "99999999999"
    },
    "address": {
      "street_name": "R. Ângelo Piva",
      "street_number": "144",
      "zip_code": "06210110",
      "neighborhood": "Presidente Altino",
      "city": "Osasco",
      "state": "SP",
      "complement": "303"
    }
  },
  "marketplace": "NONE",
  "marketplace_fee": "10.00",
  "items": [
    {
      "title": "Some item title",
      "unit_price": "1000.00",
      "quantity": 1,
      "description": "Some item description",
      "external_code": "item_external_code",
      "category_id": "category_id",
      "type": "item type",
      "picture_url": "https://mysite.com/img/item.jpg"
    }
  ],
  "expiration_time": "P3D"
}
``` 