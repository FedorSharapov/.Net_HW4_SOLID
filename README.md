# HW4_SOLID

### Описание/Пошаговая инструкция выполнения домашнего задания:
На примере реализации игры «Угадай число» продемонстрировать практическое применение SOLID принципов.
Программа рандомно генерирует число, пользователь должен угадать это число. При каждом вводе числа программа пишет больше или меньше отгадываемого. Кол-во попыток отгадывания и диапазон чисел должен задаваться из настроек.
В отчёте написать, что именно сделано по каждому принципу.
Приложить ссылку на проект и написать, сколько времени ушло на выполнение задачи.


### Отчет по домашнему заданию
S - Принцип единственной ответственности. Каждый класс `GamePlay`, `GameInit`, `GameSetting` и т.д. выполняет свою одну единственную задачу и только "одну" причину для изменения.   
O - Принцип открытости/закрытости. Класс `Game` наследует класс `GamePlay` и расширяет его функционал не измененяя базовый.   
L - Принцип подстановки Лисков   
I - Принцип разделения интерфейсов. Интерфейс `IGame` разделен на интерфейсы `IGameInit`, `IGamePlay`, `IGameRules` и это позволяет классу `GamePlay` реализовывать `IGamePlay`, классу `GameInit` реализовывать `IGameInit`, а классу `Game` реализовывать все эти интерфейсы. Т.о. данное разделение интерфейсов при их реализации позволяет зависеть только от тех методов, которые необходимы и будут использоваться. А также писать менее связный код, который легче модифицировать и обновлять.   
D - Принцип инверсии зависимостей. Класс `Game` не зависит от конретной реализации `ConsoleGameManager`, а зависит от абстракции `IGameManager` и это позволяет создавать разные реализации менеджера игры.   
