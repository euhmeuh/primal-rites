require gbforth/lib/tileset.fs

ROM
create ground-tileset-data

l: ........
l: ........
l: ........
l: ........
l: ........
l: ........
l: ........
l: ........

l: ..-..... \ grass
l: ...-..*-
l: ...-.*-.
l: -*...*-.
l: -.*..-..
l: .-*.-...
l: .-..-..-
l: ......-.

l: ..@@@@.. \ human0
l: ..@.@...
l: ..@@@@..
l: ..-@@-..
l: .@@@@@@.
l: .*@@@@*.
l: ..****..
l: ..@-@-..

l: ..@@@@.. \ human1
l: ..@.@...
l: ..@@@@..
l: ..-@@-..
l: .@@@@@@.
l: .*-@@@*.
l: ..****..
l: .@-..@-.

l: ..@@@@.. \ human2
l: ..@.@...
l: ..@@@@..
l: ..-@@-..
l: .@@@@@@.
l: *.@@@@.*
l: ..****..
l: ...@-...

RAM

: install-ground-tileset ( -- )
  ground-tileset-data 5 install-tileset
;

