# Development enviroment architecture
В качестве архитектуры я бы выбрал следующее решение:

![alt tag](/sourcers/big_picture.png "Development enviroment architecture")​

При запросе к сервису, если клиент не авторизован, он отправляется на сервер авторизации. Далее, он авторизуется на IdentityServer-е (OAuth2 PKCE). Подгружаются роли/права и другая информация о пользователе. Эти данные кешируются в Redis. После чего, клиент получает доступ к сервису.

Дабы не тратить время на разворачивание, в качестве Framework, я бы использовал: https://steeltoe.io или [ABP FRAMEWORK](https://docs.abp.io/en/abp/latest/Samples/Microservice-Demo)

Сами сервисы представляют собой отдельные модули обработки заказа. В качестве шаблона использовал бы [Orchestration-based saga](https://microservices.io/patterns/data/saga.html). Для её реализации использовал бы MassTransit. На схеме ниже OrderProcessor представлен в качестве StateMachine.

![alt tag](/sourcers/services1.png "Services")​

Остальные сервисы представляют собой классическое MVC Web API приложение. 

Также добавил бы в сервисы:
* OpenTelemetry для распределённой трассировки,
* Autofac
* Automapper
* EF

Можно было бы ещё добавить Discovery Serivece (оопционально).

# Пример кода
При разворачивании сервисов-пустышек, собственного кода мало. Идут, в основном, бызовые настройки сервисов их их фильтров в которых собственного кода не видно.
В качестве примера кода, прикладываю черновые наброски для обработки "каких-то" данных. 
Основной код расположен в:
* Demo.Example\SomeWorkProcessor.cs 
* Demo.Example\Handlers\HandlerCreator.cs 
