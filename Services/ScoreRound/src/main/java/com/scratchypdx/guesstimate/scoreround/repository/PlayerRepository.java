package com.scratchypdx.guesstimate.scoreround.repository;

import com.scratchypdx.guesstimate.scoreround.model.Guess;
import com.scratchypdx.guesstimate.scoreround.model.Player;

import java.util.ArrayList;

public interface PlayerRepository {

    public Player getPlayer(int id);
    public Player getPlayer(String name);
    public ArrayList<Player> getPlayers();
    public Player addPlayer(Player player);
    public Player updatePlayerScore(Player player);
    public void deletePlayer(Player player);
    public void deleteAllPlayers();
}
