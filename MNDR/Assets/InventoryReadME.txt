Read me Inventory System
The implementation of the inventory for this project is a little "Janky",
Inside the XR Origin> Camera offset> LeftHandController> HandMenu 
You will find UI Inventory, Gaze Interactor, and the attach transform.

UIInventory 
consists of a panel and inside the panel we have a button and 
when it gets pressed it turns a scroll view active, the scrollview>Viewport>Content contains about 50 buttons  and 
when they get pressed they spawn an item. each button references the IDscript attached to itself. in the inspector youll find that the item 
you want to spawn is called "item to spawn", when it spawn in the item it gets set to recent item and then the button that spawned, that button cannot be pressed again
additionally there is a socket that destroys items that get placed inside it. 

Destroying Cards
in order for the button to be pressable again there is a condition that needs to be met.
in the inspector on the button in IDScript "Recent Item" must be null and the bool "I was Collected" must be true.
there are two methods we have decided on to destroy the cards.
1. there is a socket that is shaped like a trashcan, it is under HandMenu>UIInventory>Socket
   when an item gets placed in the socket it gets destroyed 
2. I personally did not implement this method but i believe one of the other devs has added 
   a timer to the card prefabs that destroys the card after a certain amount of time 

Gaze Interactor 
The Gaze intoractor is an Ray that is child under the LeftHandController>HandMenu>GazeInteractor
the gaze interactor contains the XR Gaze Interactor component.
the component operates on the HeadGazeInteractor Layer
when the ray comes Hovers over a collider it then sets the UIInventory Gameobject active 
and on hover exit it sets it inactive.
