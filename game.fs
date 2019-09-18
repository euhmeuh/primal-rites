\ Primal Rites
\ GameBoy game by euhmeuh
\ Copyright (C) 2019 Jerome Martin

require tileset.fs
require gbforth/lib/ibm-font.fs
require gbforth/lib/term.fs

20 constant /width
16 constant /height

ROM

create PATTERNS
%11111000 c, %00000000 c, %11110000 c,
%11111111 c, %11100000 c, %00110000 c,
%01111111 c, %11000000 c, %00110000 c,
%00111110 c, %00000000 c, %00010000 c,
%00111100 c, %00000000 c, %00000000 c,
%00111000 c, %00000000 c, %00000000 c,
%00000000 c, %00000000 c, %00010000 c,
%00000000 c, %00000000 c, %00010000 c,
%00000000 c, %00000000 c, %00010000 c,
%00000000 c, %01100000 c, %00110000 c,
%00010000 c, %01100000 c, %00110000 c,
%00011000 c, %00000000 c, %00110000 c,
%00011000 c, %00000000 c, %00110000 c,
%00010000 c, %00000000 c, %01110000 c,
%00010000 c, %00000000 c, %01110000 c,
%00000000 c, %00001111 c, %11110000 c,

create SCREENS
( 4pattern 2res 2rotation )
\ ," Forest" 1 c,
%00000000 c,
%00000000 c,
%00000000 c,

create MENU
B-FULL B-FULL
2dup 2dup 2dup 2dup 2dup 2dup 2dup 2dup 2dup
c, c, c, c, c, c, c, c, c, c,
c, c, c, c, c, c, c, c, c, c,

RAM

create MAP-LINE

: map-line! ( tile idx -- )
  MAP-LINE + c!
;

: show-map-line ( -- )
  MAP-LINE 8 type
;

: check-tile ( line -- )  128 and if 1 else 0 then ;
: next-tile  ( line -- )  1 lshift ;
: show-tiles ( line -- )
  8 0 do
    dup check-tile
    if B-GRASS else B-EMPTY then
    i map-line! next-tile
  loop
  drop show-map-line
;

: show-level ( -- )
  /height 0 do
    PATTERNS i 3 * +
    dup c@ show-tiles
    dup 1 + c@ show-tiles
    dup 2 + c@ show-tiles
    cr
  loop 
;

: show-menu ( -- )
  MENU 20 type cr
  MENU 20 type cr
;

: show-human ( x y -- )
  at-xy B-HUMAN-0 emit
;

: main
  install-game-tileset
  show-menu
  show-level
  10 10 show-human
;

