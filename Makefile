
GBFORTH=./gbforth/gbforth
EMULATOR=mednafen

.PHONY: all

all:
	$(GBFORTH) game.fs

run:
	$(EMULATOR) game.gb

