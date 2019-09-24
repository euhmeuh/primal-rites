\ Primal Rites
\ GameBoy game by euhmeuh
\ Copyright (C) 2019 Jérôme Martin

require tileset.fs
require gbforth/lib/gbhw.fs
require gbforth/lib/input.fs
require gbforth/lib/term.fs

20 constant VIEW-W
16 constant VIEW-H
32 constant MAP-W
32 constant MAP-H

ROM

create PATTERNS
%11111000 c, %00000000 c, %10000111 c, %10000100 c,
%11111111 c, %11100000 c, %00000011 c, %11001110 c,
%01111111 c, %11000000 c, %00000011 c, %11001111 c,
%00111110 c, %00000000 c, %00000001 c, %01001111 c,
%00111100 c, %00000000 c, %00000000 c, %01001100 c,
%00111000 c, %00000000 c, %00000000 c, %00000100 c,
%00000000 c, %00000000 c, %00000001 c, %00001100 c,
%00000000 c, %00000000 c, %00000001 c, %10001110 c,
%00000000 c, %00000000 c, %00000001 c, %10001110 c,
%00000000 c, %01100000 c, %00000011 c, %11001110 c,
%00010000 c, %01100000 c, %00000011 c, %11111100 c,
%00011000 c, %00000000 c, %00000011 c, %11111000 c,
%00011000 c, %00000000 c, %00000011 c, %00111100 c,
%00010000 c, %00000000 c, %00000111 c, %00001110 c,
%00010000 c, %00000000 c, %00000111 c, %00001111 c,
%00000000 c, %00000011 c, %00000000 c, %00001111 c,
%00000000 c, %00000111 c, %00000000 c, %00000111 c,
%00000000 c, %00000111 c, %00110000 c, %00000000 c,
%00000000 c, %00001110 c, %00000000 c, %00001100 c,
%00000000 c, %00001110 c, %00000000 c, %00001100 c,
%00000000 c, %00000110 c, %00000000 c, %00000000 c,
%00000000 c, %00000110 c, %00001100 c, %00000110 c,
%00000000 c, %00001110 c, %00001100 c, %00000000 c,
%00000000 c, %00001111 c, %00000000 c, %00000000 c,
%00000000 c, %00001111 c, %00000000 c, %01100000 c,
%00000000 c, %00001111 c, %00000000 c, %11000000 c,
%01100000 c, %00111111 c, %00000000 c, %00001100 c,
%00110000 c, %11111111 c, %11000000 c, %00001100 c,
%00011000 c, %01111111 c, %11100000 c, %00000000 c,
%00111000 c, %00011111 c, %01111100 c, %00000000 c,
%00011000 c, %00011111 c, %00111000 c, %00000110 c,
%00001000 c, %00001111 c, %00000000 c, %00000110 c,

create SCREENS
( size layer1 layer2 layer3 )
1 c,
( 4pattern 4resource )
%00000000 c,
%00000000 c,
%00000000 c,

RAM

create MAP-LINE 8 allot

: !map-line ( tile idx -- )  MAP-LINE + c! ;
: .map-line ( -- )  MAP-LINE 8 type ;

: check-tile ( line -- )  128 and ;
: next-tile  ( line -- )  1 lshift ;
: show-tiles ( line -- )
  8 0 do
    dup check-tile
    if B-GRASS else B-EMPTY then
    i !map-line next-tile
  loop
  drop .map-line
;

: show-level ( -- )
  MAP-H 0 do
    PATTERNS i 4 * +
    dup c@ show-tiles
    dup 1 + c@ show-tiles
    dup 2 + c@ show-tiles
    dup 3 + c@ show-tiles
    cr
  loop 
;

: show-human ( x y -- )
  at-xy B-HUMAN-0 emit
;

: .ui
  show-level
  10 10 show-human
;

: sleep ( n -- )  0 do wait loop ;

: scrollx ( n -- )  rSCX @ + rSCX c! ;
: scrolly ( n -- )  rSCY @ + rSCY c! ;

: handle-input
  begin
    key-state
    dup k-up   and if -1 scrolly then
    dup k-down and if  1 scrolly then
    dup k-left and if -1 scrollx then
    k-right    and if  1 scrollx then
    16 sleep
  again
;

: main
  install-game-tileset
  init-input
  .ui
  handle-input
;

