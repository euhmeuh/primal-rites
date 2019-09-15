
require ground-tileset.fs
require gbforth/lib/term.fs

20 constant /width
18 constant /height

ROM

create LEVEL-0
1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 2 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 2 c, 1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 4 c, 0 c, 0 c, 0 c,
0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 3 c, 0 c, 0 c, 0 c, 0 c, 0 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c,
1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c,
1 c, 1 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 0 c, 1 c, 1 c,

RAM

: show-level ( -- )
  /height 0 do
    LEVEL-0 dup i /width * +
    /width type cr
  loop 
;

: main
  install-ground-tileset
  show-level
;

