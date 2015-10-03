<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
      <html>
        <body>
          <h1>Students</h1>
          <xsl:for-each select="students/student">
            <div style="border:3px solid black">
              <div>Name : <xsl:value-of select="name"/></div>
              <div>Sex : <xsl:value-of select="sex"/></div>
              <div>Birth Date : <xsl:value-of select="birthDate"/></div>
              <div>Phone : <xsl:value-of select="phone"/></div>
              <div>Email : <xsl:value-of select="email"/></div>
              <div>Course : <xsl:value-of select="course"/></div>
              <div>Speciality : <xsl:value-of select="speciality"/></div>
              <div>Faculty Number : <xsl:value-of select="facultyNumber"/></div>
              <!-- <div style="border:1px solid black">Enrollment Info : 
                <xsl:value-of select="date"/>
              </div> -->
            </div>
          </xsl:for-each>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
