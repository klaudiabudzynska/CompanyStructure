# CompanyStructure

Aplikacja służąca do podglądu struktury organizacji. Obsługiwane są rejestracja i logowanie obsłużone za pomocą Identity Framework. 
Autentykacja zabezpieczona za pomocą JWT i ról przypisanych użytkownikom.

## Instrukcja uruchomienia

Baza danych stworzona lokalnie, o nazwie CompanyDB
Api działa na porcie 7298 i 5298
Dokumentacja requestów dostępna pod adresem /swagger/index.html

Aplikacja do otwarcia w Visual Studio 2019 i wyżej

## Przykładowy request

```
curl -X 'POST' \
  'https://localhost:7298/api/Account/login' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "email": "user@example.com",
  "password": "stringst"
}'
```
