# PlayneraTest


# Unity 2022.3.54f1
# 3rd party assets: Zenject, UniRx

# Описание: 
  Для написания тестового использолся компонентный подход. В качесте Di фреймворка Zenject
  Реализованные механики: перемещение объектов по сцене, скролл камеры.
  На сцене есть SceneInstaller, в котором биндятся все зависимости на сцене. Также есть GameObject Installer для биндинга всех компонентов Яблока (Apple) : Apple Installer
  IObjFacade - по большей части фасад для игровых объектов на сцене. Проверка компонентов на объектке: IObjFacade.TryGet(out component).
  Компоненты объетка: GroundComponent, FallComponent, GrabComponent
  AppleController - контроллер для яблока, чтобы настроисть компоненты у объекта
  ApplePresenter/ View - классы, которые отвечают за визуальое представление объекта
  TouchHandler - медиатор для работы с инпутом.
  ObjTouchHandler - класс, который отлавливает тачи по самому объекту.
  ScrollHandler - система для скролла сцены
