<template>
    <div id ="aboutus">
       
        <div id ="description"> <p>Welcome to our tournament hosting site! Whether you're looking to host your own tournament, join a tournament, or casually browse, we've got you covered.</p> </div>
        
        
        <div id ="features"><p> If competitions aren't your thing, that's cool. You can browse past, present, and future tournaments without having to register.
        Maybe they are, but the idea of having to set up, organize, and manage a tournament makes you want to run away screaming, then that's okay. You can simply register as a participant-only and never have to worry about getting trophies made or creating a tournament. 
        If you're the ambitious coach who wants to start your first annual tournament, you're able to register as a participant AND host, so you can join others' tournaments while also beng able to create and modify your own. </p> 
        </div>

        <div id="profiles" >
<div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C4E03AQFy_6ZGwZvBhQ/profile-displayphoto-shrink_200_200/0/1612003848821?e=1623283200&v=beta&t=f7VLyS222lYwaf0OSb4t-h0iMT2PZdhaKYGriwDC460" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Gerry</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="https://www.linkedin.com/in/gerryruff/" target="_blank" class="btn btn-outline-light">Go somewhere</a>
    
  </div>
</div>
         <div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C4D03AQE46vz_eISWCQ/profile-displayphoto-shrink_200_200/0/1611349393941?e=1623283200&v=beta&t=eJ-n9NS7JDmQehMQgKwMtijwLgU3MfqpWEt_LZEm88U" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Jesse</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="https://www.linkedin.com/in/jesse-hofmann/" target="_blank" class="btn btn-outline-light">Go somewhere</a>
    
  </div>
</div>
          <div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C5603AQHagAEbIwuu1A/profile-displayphoto-shrink_200_200/0/1612213620622?e=1623283200&v=beta&t=TYi4zqQrC_uujaVd-FxL957ybKF4Wdj_Uhx9L6PjInw" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Drake</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="https://www.linkedin.com/in/drake-lundstrom/" target="_blank" class="btn btn-outline-light">Go somewhere</a>
    
  </div>
</div>
           <div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C4E03AQHDfveFZMRHRw/profile-displayphoto-shrink_200_200/0/1611509060134?e=1623283200&v=beta&t=WStT6dIHTGW0Qd8pzA4QWTao4lPvP--Dfa2IKYpy-c0" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Emily</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="https://www.linkedin.com/in/emily-lumbert/" target="_blank" class="btn btn-outline-light">Go somewhere</a>
    
  </div>
</div>
           </div>

        <p></p>
        </div>
</template>

<script>
export default {

}
</script>

<style>
#profiles{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    justify-items: center;
    
}
.card{

    color: #cfe9af;
    
    
    background-color: #abbad3;
}

.card-text{
     text-shadow: .5px .5px .5px #abd874;
    color: #e7f4d7;
    font-size: 15px;
    
}
.card-title{
    text-shadow: 0px 2px 3px black;
   
}

footer{
    display: none;
}






</style>