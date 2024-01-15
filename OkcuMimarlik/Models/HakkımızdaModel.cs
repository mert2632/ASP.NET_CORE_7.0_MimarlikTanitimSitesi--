using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MertProje.Models;

public class HakkımızdaModel
{
    [Key]
    public int HakkımızdaID { get; set; }
    public string? HakkımızdaBaşlık { get; set; }
    public string? Hakkımızdaİmage { get; set; }
    public string? HakkımızdaPersonelİmage1 { get; set; }
    public string? HakkımızdaPersonelİmage2 { get; set; }
    public string? HakkımızdaAçıklama { get; set; }
    public string? PersonelFullName1 { get; set; }
    public string? PersonelFullName2 { get; set; }

    public string? PersonelGörev1 { get; set; }
    public string? PersonelGörev2 { get; set; }


    public string? PersonelFacebook1 { get; set; }
    public string? PersonelFacebook2 { get; set; }

    public string? PersonelGmail1 { get; set; }
    public string? PersonelGmail2 { get; set; }

    public string? PersonelLinkledin1 { get; set; }
    public string? PersonelLinkledin2 { get; set; }

    public string? Personelİnstegram1 { get; set; }
    public string? Personelİnstegram2 { get; set; }



}