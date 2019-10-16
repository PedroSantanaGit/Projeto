function Enviar1() {

    let n1 = parseFloat(document.getElementById("txtN1").value)
    console.log("N1 = " + n1);
    let n2 = parseFloat(document.getElementById("txtN2").value)
    console.log("N2 = " + n2);
    total = Number(n1) + Number(n2);
    console.log(n1 + " + " + n2 + " = " + total)
    document.getElementById("lblTexto").innerHTML = "Resultado: " + total.toFixed(2);
    document.getElementById("lblTextoBin").innerHTML = "Resultado binário: " + total.toString(2);

    const template = `Olá desenvolvedor, o resultado da soma foi: ${total}
convertendo para binário, ficará como: ${total.toString(2)}`;
    console.log(template);

}

function AdicionarComentario()
 {
    let Nome = document.getElementById("Nome").value;
    let Mensagem = document.getElementById("comment").value;
    var today = new Date();
    var date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear() ;
    let ComentarioPadrao =
        `
<div class="media border p-3">
  <img src="img_avatar3.png" alt="John Doe" class="mr-3 mt-3 rounded-circle" style="width:60px;">
  <div class="media-body">
    <h4>`+ Nome +` <small><i>`+ date + `</i></small></h4>
    <p>`+ Mensagem + `</p>
  </div>
</div>
`;

    let ComentarioAdicional =
        `
<div class="media p-3">
<img src="img_avatar2.png" alt="Jane Doe" class="mr-3 mt-3 rounded-circle" style="width:45px;">
<div class="media-body">
  <h4>Jane Doe <small><i>Posted on February 20 2016</i></small></h4>
  <p>Lorem ipsum...</p>
</div>
</div>  
`;



    let element = document.getElementById("Comentario");
    if (element.innerHTML == "") {
        element.innerHTML = ComentarioPadrao;
    }




}

function ExcluirComentario()
{
    let element = document.getElementById("Comentario");
    element.innerHTML = "";
}

function EditarComentario()
{
    let Nome = document.getElementById("Nome").value;
    let Mensagem = document.getElementById("comment").value;
    var today = new Date();
    var date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear() ;
    let ComentarioPadrao =
        `
<div class="media border p-3">
  <img src="img_avatar3.png" class="mr-3 mt-3 rounded-circle" style="width:60px;">
  <div class="media-body">
    <h4>`+Nome+`<small><i>`+" "+ date + `</i></small></h4>
    <p>`+ Mensagem + `</p>
  </div>
</div>
`;

let element = document.getElementById("Comentario");
if (Mensagem != "") {
    element.innerHTML = ComentarioPadrao;

    document.write(`<div class="media border p-3">
    <img src="img_avatar3.png" alt="John Doe" class="mr-3 mt-3 rounded-circle" style="width:60px;">
    <div class="media-body">
      <h4>`+ Nome +` <small><i>`+ date + `</i></small></h4>
      <p>`+ Mensagem + `</p>
    </div>
  </div>`)
}
}