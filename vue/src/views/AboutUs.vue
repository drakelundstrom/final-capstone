<template>
   
      <div class ="aboutus">
       
        <h1 id="aboutheader"> ABOUT US</h1>

        <div id="profiles" >
<div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C4E03AQFy_6ZGwZvBhQ/profile-displayphoto-shrink_200_200/0/1612003848821?e=1623283200&v=beta&t=f7VLyS222lYwaf0OSb4t-h0iMT2PZdhaKYGriwDC460" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Gerry</h5>
    <p class="card-text">Also know as Gary/Jerry, replies to both, but it's Gerry pronounced Gary.</p>
    <a href="https://www.linkedin.com/in/gerryruff/" target="_blank" class="btn btn-outline-light">linkedin</a>
    
  </div>
</div>
         <div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C4D03AQE46vz_eISWCQ/profile-displayphoto-shrink_200_200/0/1611349393941?e=1623283200&v=beta&t=eJ-n9NS7JDmQehMQgKwMtijwLgU3MfqpWEt_LZEm88U" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Jesse</h5>
    <p class="card-text">Glasses sold separately.</p>
    <a href="https://www.linkedin.com/in/jesse-hofmann/" target="_blank" class="btn btn-outline-light">Linkedin</a>
    
  </div>
</div>
          <div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C5603AQHagAEbIwuu1A/profile-displayphoto-shrink_200_200/0/1612213620622?e=1623283200&v=beta&t=TYi4zqQrC_uujaVd-FxL957ybKF4Wdj_Uhx9L6PjInw" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Drake</h5>
    <p class="card-text">Likes food, likes coding, hates javascript.</p>
    <a href="https://www.linkedin.com/in/drake-lundstrom/" target="_blank" class="btn btn-outline-light">linkedin</a>
    
  </div>
</div>
           <div class="card shadow-lg p-3 mb-5 bg-body rounded" style="width: 18rem;">
  <img class="card-img-top rounded-circle shadow p-3 mb-5 bg-body rounded" src="https://media-exp1.licdn.com/dms/image/C4E03AQHDfveFZMRHRw/profile-displayphoto-shrink_200_200/0/1611509060134?e=1623283200&v=beta&t=WStT6dIHTGW0Qd8pzA4QWTao4lPvP--Dfa2IKYpy-c0" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">Emily</h5>
    <p class="card-text">Will take personal offense if you criticize the styling.</p>
    <a href="https://www.linkedin.com/in/emily-lumbert/" target="_blank" class="btn btn-outline-light">linkedin</a>
    
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

.aboutus{
  background-image: url("../../assets/bnwbackground.png");
  background-color: #cccccc; 
  height: 90vh; 
  background-position: center; 
  background-repeat: no-repeat; 
  background-size: cover;
   background-attachment: fixed;
}
#profiles{
  margin-top: 25px;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr 1fr;
    justify-items: center;
    
}
.card{

    color:  #dfff99;
    
    
    background-color: #651fff;
}

.card-text{
     text-shadow: .5px .5px .5px #b9ff1f;
    color: #e7f4d7;
    font-size: 15px;
    
}
.card-title{
    text-shadow: 0px 2px 3px black;
   
}





#aboutheader{
     text-shadow: 1px 1px 2px black, 0 0 1em #651fff  , 0 0 0.2em #651fff  ;
    font-size: 35px;
}




</style>