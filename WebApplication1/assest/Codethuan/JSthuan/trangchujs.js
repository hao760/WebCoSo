

var counter = 1;
    setInterval(function(){
      document.getElementById('radio' + counter).checked = true;
      counter++;
      if(counter > 4){
        counter = 1;
      }
    }, 2000);

    const scroll_top = document.querySelector('#scroll-top');
  
window.onscroll = () => {
      if(window.scrollY > 400)
        scroll_top.classList.add('active')
      else
        scroll_top.classList.remove('active')
  }

scroll_top.addEventListener('click', () => window.scrollTo({
      top: 0,
      behavior: 'smooth',
    }));

function scroll(){
  window.scrollTo({
    behavior: 'smooth',
})};








