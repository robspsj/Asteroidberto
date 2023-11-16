# Logs

### 2023/11/15 14:31

I'm starting the project now, before i setup source control and make some other decisions
I wanna see the shape that i want to get the code in, Initially my goal is to set a simple 
implementation that gets the Asteroids game concept working as soon as possible.
I'm planning to use the observer pattern extensively to drive the visual feedbacks,
initially I'm not planning to use any specific framework for this, but if the 
implementation ends up too cumbersome I may introduce UniRx package to the project


### 2023/11/15 15:03

I Liked this implementation because instead of having every system aware of and
directly accessing each other
```mermaid
graph
    ShipInput --> BoosterView
    ShipInput --> ShipMovementController
    ShipCollision --> BoosterView
    ShipMovementController --> ShipCollisions
    Bullet --> ShipCollision
    ShipInput --> ShipGun
    ShipCollision --> ShipGun
```

we can do something like this where all the systems are aware of a shared system state
```mermaid
graph LR
    Bullet --> ShipCollision
    ShipInput --> ShipStateController
    ShipCollision --> ShipStateController
    ShipStateController --> BoosterView
    ShipStateController --> ShipGun
    ShipStateController --> ShipMovementController
```

this will also give us more liberty to customize some behaviours after the base game is implemented

### 2023/11/16 16:51
Quick stop to create git repository and start tracking progress