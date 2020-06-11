create sequence if not exists game_sequence increment by 1 start with 1;

create table if NOT EXISTS  game
(
    id     bigint primary key default nextval('game_sequence'::regclass),
    title  varchar(200)       default '%',
    phrase varchar(200)       default '%'
);

insert into game( title, phrase) values ('mass effect 2','Is simply awe-inspiring ');
insert into game( title, phrase) values ('the last of us','the most beautiful game seen on any console');



