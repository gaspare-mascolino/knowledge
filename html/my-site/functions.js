
var myName = "Gaspare";
var mySurname = "Mascolino";
var isVisible = true;
value = 0.01;

function start() {

    let n_index = 0;
    let s_index = 0;

   // Name animation
    setInterval(() => {

      if(myName[n_index]) {
          document.getElementById("myName").innerHTML = document.getElementById("myName").innerHTML + myName[n_index];
          n_index+=1;
      }
      else if(mySurname[s_index]) {
        
        document.getElementById("name-input").style.setProperty("background-color","rgba(205, 46, 52, 0.9)");
        document.getElementById("mySurname").innerHTML = document.getElementById("mySurname").innerHTML + mySurname[s_index];
        s_index+=1;
    }
      else{
       
        setInterval(() => {
          if(value < 0.7) {
            document.getElementById("enter").style.setProperty("visibility","visible");
            document.getElementById("enter").style.setProperty("opacity", value);
            document.getElementById("links").style.setProperty("visibility","visible");
            document.getElementById("links").style.setProperty("opacity", value);
            value +=0.01  
    
          }
          else{
            clearInterval();
          }
        }, 200)
        
        clearInterval();
        
      }
    }, 100)
    
    
}

function cursorAnimation() {
  // visible and hidden the cursor
  setInterval(() => {
      
    if(isVisible) {
      document.getElementById("name-input").style.setProperty("visibility", "hidden");
    }
    else{
      document.getElementById("name-input").style.setProperty("visibility", "visible");
    }

    isVisible = !isVisible;
  
},500)
}

function underline(id){
  document.getElementById(id).style.setProperty("text-decoration", "underline");
}

function removeUnderline(id){
  document.getElementById(id).style.setProperty("text-decoration", "none");
}

function enterClicked() {
  

}


start();
cursorAnimation();
