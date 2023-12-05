# Сollecting Bots

Создадим 3D игру с плоской картой. Камера позволяет наблюдать за всем пространством уровня. Реализовать следующие механики:

1. В начале игры на базе находятся три юнита

2. Во время игры в случайных местах уровня генерируются ресурсы (на ваш выбор)

3. База может сканировать пространство уровня на наличие ресурсов

4. Если у базы есть свободный юнит и несобранный ресурс, она отправляет  юнита собрать этот ресурс

5. Когда юнит получил координаты ресурса, он физически берет ресурс и несет его на базу

6. У базы есть показатель количества доступных ресурсов. Когда юнит приносит новый ресурс, этот показатель увеличивается. Сам юнит ожидает дальнейших указаний

Сдавать как проект на Github + видео
