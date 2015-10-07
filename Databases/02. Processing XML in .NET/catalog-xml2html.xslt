<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:template match="/">
      <html>
        <body>
          <h2>Catalog</h2>
          <xsl:for-each select="/catalog/album">
            <div>
              <div>
                <xsl:value-of select="name" />
                <span> - </span>
                <xsl:value-of select="artist"/>
              </div>
              <table>
                <tbody>
                  <tr>
                    <td>
                      <xsl:value-of select="year" />
                      <span>y.</span>
                    </td>
                    <td>
                      <xsl:value-of select="producer" />
                    </td>
                    <td>
                      <xsl:value-of select="price" />
                      <span>$</span>
                    </td>
                  </tr>
                </tbody>
              </table>
              <ul>
                <xsl:for-each select="/catalog/album/songs/song">
                  <li>
                    <xsl:value-of select="title" />
                    <span> - </span>
                    <xsl:value-of select="duration"/>
                  </li>
                </xsl:for-each>
              </ul>
            </div>
          </xsl:for-each>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
