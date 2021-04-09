<template>
  <main id="tournament">
  <ul class="round round-2">
    <li class="spacer">&nbsp;</li>
    
    <li class="game game-top winner">Lousville <span>82</span></li>
    <li class="game game-spacer">&nbsp;</li>
    <li class="game game-bottom ">Colo St <span>56</span></li>

    <li class="spacer1">&nbsp;</li>
    
    <li class="game game-top winner">Oregon <span>74</span></li>
    <li class="game game-spacer">&nbsp;</li>
    <li class="game game-bottom ">Saint Louis <span>57</span></li>

    <li class="spacer1">&nbsp;</li>
    
    <li class="game game-top ">Memphis <span>48</span></li>
    <li class="game game-spacer">&nbsp;</li>
    <li class="game game-bottom winner">Mich St <span>70</span></li>

    <li class="spacer1">&nbsp;</li>
    
    <li class="game game-top ">Creighton <span>50</span></li>
    <li class="game game-spacer">&nbsp;</li>
    <li class="game game-bottom winner">Duke <span>66</span></li>

    <li class="spacer">&nbsp;</li>
  </ul>
  <ul class="round round-3">
    <li class="spacer">&nbsp;</li>
    
    <li class="game game-top winner">Lousville <span>77</span></li>
    <li id ="spacing1" class="game game-spacer">&nbsp; </li>
    <li class="game game-bottom ">Oregon <span>69</span></li>

    <li class="spacer">&nbsp;</li>
    
    <li class="game game-top ">Mich St <span>61</span></li>
    <li id ="spacing1" class="game game-spacer">&nbsp;</li>
    <li class="game game-bottom winner">Duke <span>71</span></li>

    <li class="spacer">&nbsp;</li>
  </ul>
  <ul class="round round-4">
    <li class="spacer">&nbsp;</li>
    
    <li class="game game-top winner">Lousville <span>85</span></li>
    <li id="spacefinal" class="game game-spacer">&nbsp;</li>
    <li class="game game-bottom ">Duke <span>63</span></li>
    
    <li class="spacer">&nbsp;</li>
  </ul>
  <ul class="round round-5">
      <li class="game winner">Lousville <span>85</span></li>
  </ul>   
</main>
</template>

<script>
export default {
    name: "Bracket",

}
</script>

<style>
main{
  display:flex;
  flex-direction:row;
  justify-content: center;
}
.round{
  display:flex;
  flex-direction:column;
  justify-content:center;
  width:200px;
  list-style:none;
  padding:0;
}
  .round .spacer{ flex-grow:1; }
  .round .spacer:first-child,
  .round .spacer:last-child{ flex-grow:.5; }

  .spacer1{
      padding: 10px;
  }

  .round .game-spacer{
    flex-grow:1;
  }

  #spacing1{
      flex-grow: 1.6;
  }

  #spacefinal{
      flex-grow: 1.37;
  }

  

/*
 *  General Styles
*/
body{
  padding:10px;
  line-height:1.4em;
}

li.game
{
  padding-left:20px;
}

  li.game.winner{
    font-weight:bold;
  }
  
li.game
 span{
    float:right;
    margin-right:5px;
  }

  li.game-top{ border-bottom:1px solid #aaa; }

  li.game-spacer{ 
    border-right:1px solid #aaa;
    min-height:40px;
  }

  li.game-bottom{ 
    border-top:1px solid #aaa;
  }
</style>